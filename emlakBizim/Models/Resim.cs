using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Resim
    {
        public int resimId { get; set; }
        public string resimAd { get; set; }
        public int ilanId { get; set; }
        public virtual Ilan Ilan { get; set; }
    }
}