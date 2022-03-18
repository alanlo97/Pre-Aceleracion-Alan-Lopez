using Challenge.Entities;
using System.Collections.Generic;

namespace Challenge.Core.Models.Dtos
{
    public class PersonajeDtoById
    {
        public string Image { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public string Historia { get; set; }
        public ICollection<PeliculaSerieDtoForDisplay> PeliculasSeries { get; set; }
    }
}
