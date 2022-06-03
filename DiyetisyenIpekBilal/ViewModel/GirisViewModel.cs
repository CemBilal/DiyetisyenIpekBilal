using System.ComponentModel.DataAnnotations;

namespace DiyetisyenIpekBilal.ViewModel
{
    public class GirisViewModel
    {
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "E-posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0},en az {2} en çok {1} karakter içerebilir"), DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz {0}")]
        public string Emaill { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Parola"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0},en az {2} en çok {1} karakter içerebilir"), DataType(DataType.Password, ErrorMessage = "Geçersiz {0}")]
        public string Password { get; set; }
    }
}
