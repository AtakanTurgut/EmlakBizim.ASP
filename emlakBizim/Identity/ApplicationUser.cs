using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace emlakBizim.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
}