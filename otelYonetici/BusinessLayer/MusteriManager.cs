using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using otelYonetici.DAL;
using otelYonetici.Domain;

namespace otelYonetici.Business
{
    public class MusteriManager
    {
        private readonly MusteriDal _musteriDal;

        public MusteriManager()
        {
            _musteriDal = new MusteriDal();
        }

        public bool MusteriEkle(Musteri musteri)
        {
            if (string.IsNullOrWhiteSpace(musteri.Ad) || string.IsNullOrWhiteSpace(musteri.Soyad))
            {
                throw new ArgumentException("Müşteri adı ve soyadı boş olamaz.");
            }
            return _musteriDal.Ekle(musteri);
        }

        public bool MusteriGuncelle(Musteri musteri)
        {
            if (musteri.MusteriID <= 0)
            {
                throw new ArgumentException("Geçerli bir müşteri ID girin.");
            }
            return _musteriDal.Guncelle(musteri);
        }

        public List<Musteri> TumMusterileriGetir()
        {
            return _musteriDal.TumunuGetir();
        }

        public bool MusteriSil(int musteriId)
        {
            if (musteriId <= 0)
            {
                throw new ArgumentException("Geçerli bir müşteri ID girin.");
            }
            return _musteriDal.Sil(musteriId);
        }
    }
}

