using System.ComponentModel.DataAnnotations;

namespace DiyetisyenIpekBilal.Models
{
    public class Instructions
    {
        [Key]
        public int InstructionID { get; set; }

        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Talimat")]
        public string InstructionSen { get; set; }


        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Tarif Adı")]
        public int RecipeID { get; set; }

        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Tarif Adı")]
        public Recipe recipe{ get; set; }

    }
}