using Challenge.Entities;

namespace Challenge.Core.Models.Dtos
{
    public class PersonajeDtoForInsert
    {
        public string Image { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public string Historia { get; set; }
        public int PeliculaSerie { get; set; }
    }
}
