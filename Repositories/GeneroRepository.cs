using Challenge.Context;
using Challenge.Entities;
using Challenge.Interfaces;
using static Challenge.Program;

namespace Challenge.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(ChallengeContext dbContext) : base(dbContext)
        {

        }
    }
}
