using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Context
{
    public class ChallengeContext : DbContext
    {
        private const string Schema = "Disney";

        public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);

        }

        public DbSet<Personaje> Personajes { get; set; } = null!;

        public DbSet<PeliculaSerie> PeliculasSeries { get; set; } = null!;

        public DbSet<Genero> Generos { get; set; } = null!;

    }
}
