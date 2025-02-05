using MySql.Data.MySqlClient;
using otelYonetici.Domain;
using System.Collections.Generic;
using System;

namespace otelYonetici.DAL
{
    public class MusteriDal
    {
        private readonly dbBaglanti _baglanti;

        public MusteriDal()
        {
            _baglanti = new dbBaglanti();
        }

        public bool Ekle(Musteri musteri)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "INSERT INTO tblMusteri (Ad, Soyad, Telefon, Eposta) VALUES (@ad, @soyad, @telefon, @eposta)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", musteri.Ad);
                        cmd.Parameters.AddWithValue("@soyad", musteri.Soyad);
                        cmd.Parameters.AddWithValue("@telefon", musteri.Telefon); 
                        cmd.Parameters.AddWithValue("@eposta", musteri.Eposta);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }

        public bool Guncelle(Musteri musteri)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "UPDATE tblMusteri SET Ad = @ad, Soyad = @soyad, Telefon = @telefon, Eposta = @eposta WHERE MusteriID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", musteri.MusteriID);
                        cmd.Parameters.AddWithValue("@ad", musteri.Ad);
                        cmd.Parameters.AddWithValue("@soyad", musteri.Soyad);
                        cmd.Parameters.AddWithValue("@telefon", musteri.Telefon);
                        cmd.Parameters.AddWithValue("@eposta", musteri.Eposta);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }

        public List<Musteri> TumunuGetir()
        {
            List<Musteri> musteriler = new List<Musteri>();
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblMusteri", conn))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                musteriler.Add(new Musteri
                                {
                                    MusteriID = Convert.ToInt32(dr["MusteriID"]),
                                    Ad = dr["Ad"].ToString(),
                                    Soyad = dr["Soyad"].ToString(),
                                    Telefon = dr["Telefon"].ToString(), 
                                    Eposta = dr["Eposta"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return musteriler;
        }

        public bool Sil(int musteriId)
        {
            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "DELETE FROM tblMusteri WHERE MusteriID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", musteriId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                return false;
            }
        }
    }
}