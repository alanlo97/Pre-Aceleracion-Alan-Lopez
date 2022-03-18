using System;

namespace Challenge.Core.Models.Dtos
{
    public class PeliculaSerieDtoForInsert
    {
        public string Image { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int Calificaion { get; set; }
        public int IdGenero { get; set; }
    }
}
