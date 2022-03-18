using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Entities
{
    public class PersPeliSerie : EntityBase
    {
        public int IdPersonaje { get; set; }

        [ForeignKey("IdPersonaje")]
        public Personaje Personaje { get; set; }
        public int IdPeliculaSerie { get; set; }

        [ForeignKey("IdPeliculaSerie")]
        public PeliculaSerie PeliculaSerie { get; set; }
    }
}
