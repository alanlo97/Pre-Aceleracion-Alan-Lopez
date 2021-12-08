using Challenge.Context;
using Challenge.Entities;
using Challenge.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Challenge.Program;

namespace Challenge.Repositories
{
    public class PersonajeRepository : BaseRepository<Personaje>, IPersonajeRepository
    {
        private readonly ChallengeContext _dbContext;
        public PersonajeRepository(ChallengeContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
