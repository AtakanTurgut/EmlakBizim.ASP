using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Semt
    {
        public int semtId { get; set; }
        public string semtAd { get; set; }
        public int sehirId { get; set; }
        public virtual Sehir Sehir{ get; set; }
        public List<Mahalle> mahalles { get; set; }
    }
}