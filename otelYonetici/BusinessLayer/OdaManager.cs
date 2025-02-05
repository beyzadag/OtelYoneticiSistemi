using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using otelYonetici.DAL;
using otelYonetici.Domain;

namespace otelYonetici.Business
{
    public class OdaManager
    {
        private readonly OdaDal _odaDal;

        public OdaManager()
        {
            _odaDal = new OdaDal();
        }

        public bool OdaEkle(Oda oda)
        {
            try
            {
                return _odaDal.Ekle(oda);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return false;
            }
        }

        public bool OdaGuncelle(Oda oda)
        {
            try
            {
                return _odaDal.Guncelle(oda);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return false;
            }
        }

        public bool OdaSil(int odaId)
        {
            try
            {
                return _odaDal.Sil(odaId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return false;
            }
        }

        public List<Oda> TumunuGetir()
        {
            try
            {
                return _odaDal.TumunuGetir();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return new List<Oda>();
            }
        }

    }
}

