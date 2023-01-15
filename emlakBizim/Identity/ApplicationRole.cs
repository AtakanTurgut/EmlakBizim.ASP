using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace emlakBizim.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string description { get; set; }

        public ApplicationRole()
        {

        }

        public ApplicationRole(string roleName, string description)
        {
            this.description = description;
        }
    }
}