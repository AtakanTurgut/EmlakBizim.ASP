using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Sehir
    {
        public int sehirId { get; set; }
        public string sehirAd { get; set; }
        public List<Semt> semts { get; set; }
    }
}