using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using otelYonetici.DAL;
using otelYonetici.Domain;


namespace otelYonetici.Business
{
    public class RezervasyonManager
    {
        private readonly RezervasyonDal _rezervasyonDal;

        public RezervasyonManager()
        {
            _rezervasyonDal = new RezervasyonDal();
        }

        public bool RezervasyonEkle(Rezervasyon rezervasyon)
        {
            if (rezervasyon.GirisTarihi >= rezervasyon.CikisTarihi)
            {
                throw new ArgumentException("Çıkış tarihi giriş tarihinden önce olamaz.");
            }

            if (rezervasyon.MusteriID <= 0 || rezervasyon.OdaID <= 0)
            {
                throw new ArgumentException("Geçerli müşteri ve oda ID girin.");
            }

            if (!MusteriVarMi(rezervasyon.MusteriID))
            {
                throw new ArgumentException("Belirtilen müşteri bulunamadı.");
            }

            if (!OdaVarMi(rezervasyon.OdaID))
            {
                throw new ArgumentException("Belirtilen oda zaten rezerve edildi.");
            }

            decimal odaFiyati = _rezervasyonDal.GetOdaFiyat(rezervasyon.OdaID);
            int gunSayisi = (rezervasyon.CikisTarihi - rezervasyon.GirisTarihi).Days;
            rezervasyon.ToplamTutar = odaFiyati * gunSayisi;

            bool rezervasyonEklendi = _rezervasyonDal.Ekle(rezervasyon);
            if (rezervasyonEklendi)
            {
                _rezervasyonDal.OdaDurumuGuncelle(rezervasyon.OdaID, "Dolu");
            }
            return rezervasyonEklendi;

        }

        public bool RezervasyonGuncelle(Rezervasyon rezervasyon)
        {
            if (rezervasyon.RezervasyonID <= 0)
            {
                throw new ArgumentException("Geçerli bir rezervasyon ID girin.");
            }

            if (!MusteriVarMi(rezervasyon.MusteriID))
            {
                throw new ArgumentException("Belirtilen müşteri bulunamadı.");
            }

            if (!OdaVarMi(rezervasyon.OdaID))
            {
                throw new ArgumentException("Belirtilen oda zaten rezerve edildi.");
            }

            var eskiRezervasyon = _rezervasyonDal.RezervasyonGetir(rezervasyon.RezervasyonID);
            if (eskiRezervasyon != null)
            {
                _rezervasyonDal.OdaDurumuGuncelle(eskiRezervasyon.OdaID, "Boş");
            }

            bool guncellendi = _rezervasyonDal.Guncelle(rezervasyon);
            if (guncellendi)
            {
                _rezervasyonDal.OdaDurumuGuncelle(rezervasyon.OdaID, "Dolu");
            }
            return guncellendi;
        }
        

        public List<Rezervasyon> TumRezervasyonlariGetir()
        {
            return _rezervasyonDal.TumunuGetir();
        }

        public bool RezervasyonSil(int rezervasyonId)
        {
            if (rezervasyonId <= 0)
            {
                throw new ArgumentException("Geçerli bir rezervasyon ID girin.");
            }

            var rezervasyon = _rezervasyonDal.RezervasyonGetir(rezervasyonId);
            if (rezervasyon != null)
            {
                bool silindi = _rezervasyonDal.Sil(rezervasyonId);
                if (silindi)
                {
                    _rezervasyonDal.OdaDurumuGuncelle(rezervasyon.OdaID, "Boş");
                }
                return silindi;
            }
            return false;
        }
        public Rezervasyon RezervasyonGetir(int rezervasyonId)
        {
            return _rezervasyonDal.RezervasyonGetir(rezervasyonId);
        }
        public bool MusteriVarMi(int musteriId)
        {
            var (musteriler, _) = _rezervasyonDal.GetMusteriVeOdaBilgileri();
            return musteriler.Any(m => m.MusteriID == musteriId);
        }

        public bool OdaVarMi(int odaId)
        {
            var (_, odalar) = _rezervasyonDal.GetMusteriVeOdaBilgileri();
            return odalar.Any(o => o.OdaID == odaId);
        }

        public bool Ekle(Rezervasyon rezervasyon)
        {
            if (_rezervasyonDal.OdaRezerveMi(rezervasyon.OdaID, rezervasyon.GirisTarihi, rezervasyon.CikisTarihi))
            {
                throw new InvalidOperationException("Seçilen tarihler arasında bu oda zaten rezerve edilmiş.");
            }

            return _rezervasyonDal.Ekle(rezervasyon);
        }


    }
}
