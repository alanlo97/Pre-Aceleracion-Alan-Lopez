using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class Personaje : EntityBase
    {
        [Key]
        public int IdPersonaje { get; set; }
        [Required(ErrorMessage = "La Imagen es Requerida")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La Imagen es demasiado largo")]
        public string Image { get; set; }
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "El Nombre es demasiado largo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Edad es Requerida")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "El Peso es Requerido")]
        public float Peso { get; set; }
        [Required(ErrorMessage = "La Historia es Requerida")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La Historia es demasiado largo")]
        public string Historia { get; set; }
    }
}
