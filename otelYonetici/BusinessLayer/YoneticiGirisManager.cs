using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using otelYonetici.DAL;

namespace otelYonetici.Business
{
    public class YoneticiGirisManager
    {
        private readonly YoneticiGirisDal _girisDal;

        public YoneticiGirisManager()
        {
            _girisDal = new YoneticiGirisDal();
        }

        public bool GirisYap(string yoneticiIsim, string sifre)
        {
            bool girisBasarili = _girisDal.GirisYap(yoneticiIsim, sifre);
            if (girisBasarili)
            {
                Console.WriteLine("Giriş başarılı!");
            }
            else
            {
                Console.WriteLine("Hatalı kullanıcı adı veya şifre!");
            }
            return girisBasarili;
        }
    }
}
