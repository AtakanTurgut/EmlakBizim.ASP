using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class ProfilGuncelleme
    {
        public string id { get; set; }

        [Required]
        [DisplayName("Adı")]
        public string name { get; set; }

        [Required]
        [DisplayName("Soyadı")]
        public string surname { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Geçerli Bir Email Adresi Giriniz!")]
        public string email { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string userName { get; set; }

    }
}