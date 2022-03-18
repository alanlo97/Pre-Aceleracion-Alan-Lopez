using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge.DataAccess
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersPeliSerie>()
                .HasKey(c => new { c.IdPeliculaSerie, c.IdPersonaje });
        }

        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<PeliculaSerie> PeliculasSeries { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
