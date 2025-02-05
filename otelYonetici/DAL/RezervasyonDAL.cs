using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using otelYonetici.Domain;
using otelYonetici.DAL;


namespace otelYonetici.DAL
{
    public class RezervasyonDal
    {
        private readonly dbBaglanti _baglanti;

        public RezervasyonDal()
        {
            _baglanti = new dbBaglanti();
        }

        public (List<Musteri>, List<Oda>) GetMusteriVeOdaBilgileri()
        {
            List<Musteri> musteriler = new List<Musteri>();
            List<Oda> odalar = new List<Oda>();

            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    // Müşterileri çek
                    string musteriQuery = "SELECT MusteriID, Ad, Soyad FROM tblMusteri";
                    using (MySqlCommand musteriCmd = new MySqlCommand(musteriQuery, conn))
                    {
                        using (MySqlDataReader musteriReader = musteriCmd.ExecuteReader())
                        {
                            while (musteriReader.Read())
                            {
                                musteriler.Add(new Musteri
                                {
                                    MusteriID = musteriReader.GetInt32("MusteriID"),
                                    Ad = musteriReader.GetString("Ad"),
                                    Soyad = musteriReader.GetString("Soyad")
                                });
                            }
                        }
                    }

                    // Odaları çek
                    string odaQuery = "SELECT OdaID, OdaNumarasi, Durum FROM tblOda WHERE Durum = 'Boş'";
                    using (MySqlCommand odaCmd = new MySqlCommand(odaQuery, conn))
                    {
                        using (MySqlDataReader odaReader = odaCmd.ExecuteReader())
                        {
                            while (odaReader.Read())
                            {
                                odalar.Add(new Oda
                                {
                                    OdaID = odaReader.GetInt32("OdaID"),
                                    OdaNumarasi = odaReader.GetInt32("OdaNumarasi"),
                                    Durum = odaReader.GetString("Durum")
                                });
                            }
                        }
                    }
                }
            }

            return (musteriler, odalar);
        }

        public bool OdaDurumuGuncelle(int odaId, string durum)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "UPDATE tblOda SET Durum = @durum WHERE OdaID = @odaId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaId", odaId);
                        cmd.Parameters.AddWithValue("@durum", durum);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }
        public decimal GetOdaFiyat(int odaId)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "SELECT Fiyat FROM tblOda WHERE OdaID = @odaId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaId", odaId);

                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToDecimal(result) : 0;
                    }
                }
                return 0;
            }
        }

        public List<Oda> TumOdalariGetir()
        {
            List<Oda> odalar = new List<Oda>();
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM tblOda";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                odalar.Add(new Oda
                                {
                                    OdaID = reader.GetInt32("OdaID"),
                                    OdaNumarasi = reader.GetInt32("OdaNumarasi"),
                                    OdaTipi = reader.GetString("OdaTipi"),
                                    Fiyat = reader.GetDecimal("Fiyat"),
                                    Durum = reader.GetString("Durum")
                                });
                            }
                        }
                    }
                }
            }
            return odalar;
        }

        public bool Ekle(Rezervasyon rezervasyon)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = @"INSERT INTO tblRezervasyon 
                                (MusteriID, OdaID, ToplamTutar, GirisTarihi, CikisTarihi) 
                                VALUES 
                                (@musteriId, @odaId, @toplamTutar, @girisTarihi, @cikisTarihi)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@musteriId", rezervasyon.MusteriID);
                        cmd.Parameters.AddWithValue("@odaId", rezervasyon.OdaID);
                        cmd.Parameters.AddWithValue("@toplamTutar", rezervasyon.ToplamTutar);
                        cmd.Parameters.AddWithValue("@girisTarihi", rezervasyon.GirisTarihi);
                        cmd.Parameters.AddWithValue("@cikisTarihi", rezervasyon.CikisTarihi);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }

        public List<Rezervasyon> TumunuGetir()
    {
        List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
        using (MySqlConnection conn = _baglanti.baglantiGetir())
        {
            if (conn != null)
            {
                string query = @"
                    SELECT 
                        r.RezervasyonID,
                        r.MusteriID,
                        r.OdaID,
                        CONCAT(m.Ad, ' ', m.Soyad) AS MusteriAdiSoyadi,
                        o.OdaNumarasi,
                        o.OdaTipi,
                        o.Fiyat,
                        r.GirisTarihi,
                        r.CikisTarihi,
                        r.ToplamTutar
                    FROM tblRezervasyon r
                    INNER JOIN tblMusteri m ON r.MusteriID = m.MusteriID
                    INNER JOIN tblOda o ON r.OdaID = o.OdaID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rezervasyonlar.Add(new Rezervasyon
                            {
                                RezervasyonID = dr.GetInt32("RezervasyonID"),
                                MusteriID = dr.GetInt32("MusteriID"),
                                OdaID = dr.GetInt32("OdaID"),
                                MusteriAdiSoyadi = dr.GetString("MusteriAdiSoyadi"),
                                OdaNumarasi = dr.GetInt32("OdaNumarasi"),
                                OdaTipi = dr.GetString("OdaTipi"),
                                GirisTarihi = dr.GetDateTime("GirisTarihi"),
                                CikisTarihi = dr.GetDateTime("CikisTarihi"),
                                ToplamTutar = dr.GetDecimal("ToplamTutar")
                            });
                        }
                    }
                }
            }
        }
        return rezervasyonlar;
    }

        public Rezervasyon RezervasyonGetir(int rezervasyonId)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = @"
                    SELECT 
                        r.RezervasyonID,
                        r.MusteriID,
                        r.OdaID,
                        CONCAT(m.Ad, ' ', m.Soyad) AS MusteriAdiSoyadi,
                        o.OdaNumarasi,
                        o.OdaTipi,
                        r.GirisTarihi,
                        r.CikisTarihi,
                        r.ToplamTutar
                    FROM tblRezervasyon r
                    INNER JOIN tblMusteri m ON r.MusteriID = m.MusteriID
                    INNER JOIN tblOda o ON r.OdaID = o.OdaID
                    WHERE r.RezervasyonID = @rezervasyonId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rezervasyonId", rezervasyonId);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                return new Rezervasyon
                                {
                                    RezervasyonID = dr.GetInt32("RezervasyonID"),
                                    MusteriID = dr.GetInt32("MusteriID"),
                                    OdaID = dr.GetInt32("OdaID"),
                                    MusteriAdiSoyadi = dr.GetString("MusteriAdiSoyadi"),
                                    OdaNumarasi = dr.GetInt32("OdaNumarasi"),
                                    OdaTipi = dr.GetString("OdaTipi"),
                                    GirisTarihi = dr.GetDateTime("GirisTarihi"),
                                    CikisTarihi = dr.GetDateTime("CikisTarihi"),
                                    ToplamTutar = dr.GetDecimal("ToplamTutar")
                                };
                            }
                        }
                    }
                }
                return null;
            }
        }


        public bool Guncelle(Rezervasyon rezervasyon)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "UPDATE tblRezervasyon SET MusteriID = @musteriID, OdaID = @odaID, GirisTarihi = @girisTarihi, CikisTarihi = @cikisTarihi, ToplamTutar = @toplamTutar WHERE RezervasyonID = @rezervasyonID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rezervasyonID", rezervasyon.RezervasyonID);
                        cmd.Parameters.AddWithValue("@musteriID", rezervasyon.MusteriID);
                        cmd.Parameters.AddWithValue("@odaID", rezervasyon.OdaID);
                        cmd.Parameters.AddWithValue("@girisTarihi", rezervasyon.GirisTarihi);
                        cmd.Parameters.AddWithValue("@cikisTarihi", rezervasyon.CikisTarihi);
                        cmd.Parameters.AddWithValue("@toplamTutar", rezervasyon.ToplamTutar);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }

        public bool Sil(int rezervasyonId)
            {
                using (MySqlConnection conn = _baglanti.baglantiGetir())
                {
                    if (conn != null)
                    {
                        string query = "DELETE FROM tblRezervasyon WHERE RezervasyonID = @rezervasyonID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@rezervasyonID", rezervasyonId);
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                    return false;
                }
            }


        public bool OdaRezerveMi(int odaID, DateTime girisTarihi, DateTime cikisTarihi)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = @"
                SELECT COUNT(*) 
                FROM tblRezervasyon 
                WHERE OdaID = @odaID 
                AND (
                    (@girisTarihi >= GirisTarihi AND @girisTarihi < CikisTarihi) OR
                    (@cikisTarihi > GirisTarihi AND @cikisTarihi <= CikisTarihi) OR
                    (@girisTarihi <= GirisTarihi AND @cikisTarihi >= CikisTarihi)
                )";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaID", odaID);
                        cmd.Parameters.AddWithValue("@girisTarihi", girisTarihi);
                        cmd.Parameters.AddWithValue("@cikisTarihi", cikisTarihi);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                return false; // Bağlantı başarısızsa false döner
            }
        }
    }
    }

