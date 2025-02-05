using System;
using MySql.Data.MySqlClient;

namespace otelYonetici.DAL
{
    class dbBaglanti
    {
        public MySqlConnection baglantiGetir()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253; Database=25_132330018; User=25_132330018; Password=!nif.ogr18DA");

            try
            {
                baglanti.Open();
                Console.WriteLine("Bağlantı başarıyla açıldı.");
                return baglanti;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
                return null;
            }
        }
    }
}
