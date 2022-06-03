using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenIpekBilal.Models
{
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }

        [Required(ErrorMessage = "{0} gerekli"),Display(Name="İsim"),StringLength(30,MinimumLength =2,ErrorMessage ="{0},en az {2} en çok {1} karakter içerebilir")]
        public string Name { get; set; }

        public string ImagePath { get; set; }
        [Display(Name = "Resim")]
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
