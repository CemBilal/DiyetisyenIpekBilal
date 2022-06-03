using System.ComponentModel.DataAnnotations;

namespace DiyetisyenIpekBilal.Models
{
    public class Rolee
    {
        [Key]
        public int RoleeID { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Role Adı"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0},en az {2} en çok {1} karakter içerebilir")]
        public string RoleeName { get; set; }
    }
}