using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class Personaje
    {

        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public string Historia { get; set; }
        public ICollection<PeliculaSerie> PeliculaSerieAsociada { get; set; }
    }
}
