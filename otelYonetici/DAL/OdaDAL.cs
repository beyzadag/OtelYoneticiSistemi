using MySql.Data.MySqlClient;
using otelYonetici.Domain;
using System;
using System.Collections.Generic;

namespace otelYonetici.DAL
{
    public class OdaDal
    {
        private readonly dbBaglanti _baglanti;

        public OdaDal()
        {
            _baglanti = new dbBaglanti();
        }

        public bool Ekle(Oda oda)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "INSERT INTO tblOda (OdaTipi, OdaNumarasi, Fiyat, Durum) VALUES (@odaTipi, @odaNumarasi, @fiyat, @durum)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaTipi", oda.OdaTipi);
                        cmd.Parameters.AddWithValue("@odaNumarasi", oda.OdaNumarasi);
                        cmd.Parameters.AddWithValue("@fiyat", oda.Fiyat);
                        cmd.Parameters.AddWithValue("@durum", oda.Durum);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }

        public bool Guncelle(Oda oda)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "UPDATE tblOda SET OdaTipi = @odaTipi, OdaNumarasi = @odaNumarasi, Fiyat = @fiyat, Durum = @durum WHERE OdaID = @odaId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaId", oda.OdaID);
                        cmd.Parameters.AddWithValue("@odaTipi", oda.OdaTipi);
                        cmd.Parameters.AddWithValue("@odaNumarasi", oda.OdaNumarasi);
                        cmd.Parameters.AddWithValue("@fiyat", oda.Fiyat);
                        cmd.Parameters.AddWithValue("@durum", oda.Durum);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }

        public bool Sil(int odaId)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "DELETE FROM tblOda WHERE OdaID = @odaId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaId", odaId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }

        public List<Oda> TumunuGetir()
        {
            List<Oda> odalar = new List<Oda>();
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM tblOda";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                odalar.Add(new Oda
                                {
                                    OdaID = Convert.ToInt32(dr["OdaID"]),
                                    OdaTipi = dr["OdaTipi"].ToString(),
                                    OdaNumarasi = Convert.ToInt32(dr["OdaNumarasi"]),
                                    Fiyat = Convert.ToDecimal(dr["Fiyat"]),
                                    Durum = dr["Durum"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return odalar;
        }
        public bool OdaDurumunuGuncelle(int odaId, string yeniDurum)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "UPDATE tblOda SET Durum = @durum WHERE OdaID = @odaId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaId", odaId);
                        cmd.Parameters.AddWithValue("@durum", yeniDurum);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }


        public Oda OdaGetir(int odaId)
        {
            Oda oda = null;
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM tblOda WHERE OdaID = @odaId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaId", odaId);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oda = new Oda
                                {
                                    OdaID = Convert.ToInt32(dr["OdaID"]),
                                    OdaTipi = dr["OdaTipi"].ToString(),
                                    OdaNumarasi = Convert.ToInt32(dr["OdaNumarasi"]),
                                    Fiyat = Convert.ToDecimal(dr["Fiyat"]),
                                    Durum = dr["Durum"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            return oda;
        }
    }
}
