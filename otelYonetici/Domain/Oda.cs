using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otelYonetici.Domain
{
   public class Oda
    {
        public int OdaID { get; set; }
        public int OdaNumarasi { get; set; }
        public string OdaTipi { get; set; }
        public decimal Fiyat { get; set; }
        public string Durum { get; set; }

        public string OdaBilgisi => $"Oda {OdaNumarasi} - {OdaTipi} ({Fiyat:C})";
        public Oda() { }

        public Oda (int odaID,int odaNumarasi,string odaTipi,decimal fiyat,string durum) 
        {
            OdaID = odaID;
            OdaNumarasi = odaNumarasi;
            OdaTipi = odaTipi;
            Fiyat = fiyat;
            Durum = durum;
        }
    }
}
