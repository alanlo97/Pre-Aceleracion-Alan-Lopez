using Challenge.Entities;
using System.Threading.Tasks;

namespace Challenge.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<PeliculaSerie> PeliculaSerieRepository { get; }
        public IRepository<Personaje> PersonajeRepository { get; }
        public IRepository<Genero> GeneroRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<PersPeliSerie> PersPeliSerieRepository { get; }
        public void Dispose();
        public void SaveChanges();
        public Task SaveChangesAsync();
    }
}
