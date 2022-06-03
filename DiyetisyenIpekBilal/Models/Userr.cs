using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenIpekBilal.Models
{
    public class Userr
    {
        [Key]
        public int UserrID { get; set; }

        [Required(ErrorMessage = "{0} gerekli"),Display(Name="İsim"),StringLength(30,MinimumLength =2,ErrorMessage ="{0},en az {2} en çok {1} karakter içerebilir")]
        public string Name{ get; set; }
        [Required(ErrorMessage = "{0} gerekli"),Display(Name="Soyisim"),StringLength(30,MinimumLength =2,ErrorMessage ="{0},en az {2} en çok {1} karakter içerebilir")]
        public string Surname{ get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "E-posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0},en az {2} en çok {1} karakter içerebilir"),DataType(DataType.EmailAddress, ErrorMessage ="Geçersiz {0}")]
        public string Emaill { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Parola"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0},en az {2} en çok {1} karakter içerebilir"),DataType(DataType.Password, ErrorMessage ="Geçersiz {0}")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Tel No."), StringLength(15, MinimumLength = 10, ErrorMessage = "{0},en az {2} en çok {1} karakter içerebilir"),DataType(DataType.PhoneNumber, ErrorMessage ="Geçersiz {0}")]
        public string PhoneNumber { get; set; }


        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Rol")]
        public int RoleeID { get; set; }
        public Rolee Rolee{ get; set; }


    }
}
