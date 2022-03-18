using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class PeliculaSerie : EntityBase
    {
        [Key]
        public int IdPeliculaSerie { get; set; }
        [Required(ErrorMessage = "La Imagen es Requerida")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La Imagen es demasiado largo")]
        public string Image { get; set; }
        [Required(ErrorMessage = "El Titulo es Requerido")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La Imagen es demasiado largo")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La Fecha de Creacion es Requerida")]
        public DateTime? FechaCreacion { get; set; }
        [Required(ErrorMessage = "La Calificacion es Requerida")]
        public int Calificaion { get; set; }  
        [Display(Name = "Id Genero")]
        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
