using Challenge.DataAccess;
using Challenge.Entities;
using Challenge.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Challenge.Repositories
{
    public class UnitOfWork
    {
        #region Constructor and Context
        private readonly ChallengeContext _dbContext;
        public UnitOfWork(ChallengeContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Repositories
        private readonly IRepository<PeliculaSerie> _peliculaSerieRepository;
        private readonly IRepository<Genero> _generoRepository;
        private readonly IRepository<Personaje> _personajeRepository;
        private readonly IRepository<User> _userrepository;
        private readonly IRepository<PersPeliSerie> _persPeliSerieRepository;

        public IRepository<PeliculaSerie> PeliculaSerieRepository => _peliculaSerieRepository ?? new Repository<PeliculaSerie>(_dbContext);
        public IRepository<Genero> GeneroRepository => _generoRepository ?? new Repository<Genero>(_dbContext);
        public IRepository<Personaje> PersonajeRepository => _personajeRepository ?? new Repository<Personaje>(_dbContext);
        public IRepository<User> UserRepository => _userrepository ?? new Repository<User>(_dbContext);
        public IRepository<PersPeliSerie> PersPeliSerieRepository => _persPeliSerieRepository ?? new Repository<PersPeliSerie>(_dbContext);

        #endregion

        #region Methods
        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
