using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenIpekBilal.Models
{
    public class AboutMe
    {
        [Key]
        public int AboutMeID { get; set; }
        [Display(Name = "Hakkımda"), DataType(DataType.Text)]
        public string AboutMee { get; set; }
        [Display(Name = "Başlık"), DataType(DataType.Text)]
        public string Titlee { get; set; }

        public string ImagePath { get; set; }
        [Display(Name = "Resim")]
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
