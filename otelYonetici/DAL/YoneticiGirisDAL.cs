using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace otelYonetici.DAL
{
    public class YoneticiGirisDal
    {
        private readonly dbBaglanti _baglanti;

        public YoneticiGirisDal()
        {
            _baglanti = new dbBaglanti();
        }

        // Yonetici Giriş Doğrulama
        public bool GirisYap(string yoneticiIsim, string sifre)
        {
            bool girisBasarili = false;

            using (MySqlConnection conn = _baglanti.baglantiGetir())
            {
                if (conn != null)
                {
                    string query = "SELECT COUNT(*) FROM tblYoneticiGiris WHERE yoneticiIsim = @yoneticiIsim AND sifre = @sifre";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Parametreleri ekleyelim
                        cmd.Parameters.AddWithValue("@yoneticiIsim", yoneticiIsim);
                        cmd.Parameters.AddWithValue("@sifre", sifre);

                        // Veritabanında eşleşen kayıt olup olmadığını kontrol ediyoruz
                        int sonuc = Convert.ToInt32(cmd.ExecuteScalar());

                        // Eğer sonuç 1 ise giriş başarılı demektir
                        if (sonuc == 1)
                        {
                            girisBasarili = true;
                        }
                    }
                }
            }
            return girisBasarili;
        }
    }
}

