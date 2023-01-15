using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Ilan
    {
        public int ilanId { get; set; }
        public string acıklama { get; set; }
        public double fiyat { get; set; }
        public int odaSayisi { get; set; }
        public int banyoSayisi { get; set; }
        public bool kredi { get; set; }
        public int alan { get; set; }
        public string kat { get; set; }
        public string telefon { get; set; }
        public string adres { get; set; }
        public string userName { get; set; }
        public int sehirId { get; set; }
        public int semtId { get; set; }
        public int durumId { get; set; }

        public int mahalleId { get; set; }
        public Mahalle Mahalle { get; set; }

        public int tipId { get; set; }
        public Tip Tip { get; set; }

        public List<Resim> resims { get; set; }
    }
}