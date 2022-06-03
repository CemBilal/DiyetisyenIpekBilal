using System.ComponentModel.DataAnnotations;

namespace DiyetisyenIpekBilal.Models
{
    public class Ingredients
    {
        [Key]
        public int IngredientsID { get; set; }

        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "İçerik Adı")]
        public string IngredientsName { get; set; }
        
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Tarif Adı")]
        public Recipe recipe { get; set; }
    }
}