using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Mahalle
    {
        public int mahalleId { get; set; }
        public string mahalleAd { get; set; }
        public int semtId { get; set; }
        public virtual Semt Semt{ get; set; }
    }
}