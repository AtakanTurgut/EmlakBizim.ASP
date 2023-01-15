using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emlakBizim.Models
{
    public class SifreDegistirme
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string oldPassword { get; set; }

        [Required]
        [DisplayName("Yeni Şifre")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz En Az 5 Karakter Olmalıdır!")]
        public string newPassword { get; set; }

        [Required]
        [DisplayName("Yeni Şifre Tekrar")]
        [Compare("newPassword", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string conNewPassword { get; set; }
    }
}