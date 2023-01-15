using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Tip
    {
        public int tipId { get; set; }
        public string tipAd { get; set; }
        public int durumId { get; set; }
        public virtual Durum Durum { get; set; }

    }
}