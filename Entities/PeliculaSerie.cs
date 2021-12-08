using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class PeliculaSerie
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public string Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int Calificaion { get; set; }
        public ICollection<Personaje> PersonajesAsociados { get; set; }

    }
}
