using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adı")]
        public string name { get; set; }

        [Required]
        [DisplayName("Soyadı")]
        public string surname { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Geçersiz Email Adresi!")]
        public string email { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string userName { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Şifreler Aynı Değil!")]
        [DisplayName("Şifre Tekrar")]
        public string rePassword { get; set; }

    }
}