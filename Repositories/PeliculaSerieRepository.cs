using Challenge.Context;
using Challenge.Entities;
using Challenge.Interfaces;
using static Challenge.Program;

namespace Challenge.Repositories
{
    public class PeliculaSerieRepository : BaseRepository<PeliculaSerie>, IPeliculaSerieRepository
    {
        public PeliculaSerieRepository(ChallengeContext dbContext) : base(dbContext)
        {

        }
    }
}
