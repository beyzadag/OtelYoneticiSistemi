using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otelYonetici.Domain
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }

        public Musteri() { }
    }
}
