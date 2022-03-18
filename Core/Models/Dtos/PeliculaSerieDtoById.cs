using Challenge.Entities;
using System;
using System.Collections.Generic;

namespace Challenge.Core.Models.Dtos
{
    public class PeliculaSerieDtoById
    {
        public string Image { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public virtual GeneroDto Genero { get; set; }
        public virtual ICollection<PersonajeDtoForDisplay> Personajes { get; set; }
    }
}
