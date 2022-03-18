using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Entities
{
    public class User : EntityBase
    {
        [Key]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El Nombre es demasiado largo")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El Password es Requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El Password es demasiado largo")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El Mail es Requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El Mail es demasiado largo")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
    }
}
