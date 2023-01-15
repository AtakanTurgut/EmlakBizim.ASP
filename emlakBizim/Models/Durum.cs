using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Durum
    {
        public int durumId { get; set; }
        public string durumAd { get; set; }
        public List<Tip> tips { get; set; }
    }
}