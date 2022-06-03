using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenIpekBilal.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "{0} gerekli"),Display(Name="Tarifin Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Talimatlar")]
        public ICollection<Instructions> Instructions { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "İçerikler")]
        public ICollection<Ingredients> Ingredients { get; set; }

        public string ImagePath { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Resim")]
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
