using Challenge.Core.Models.Dtos;
using Challenge.Core.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Core.Interfaces
{
    public interface IPersonajeService
    {
        Task<Result> Delete(int id);
        Task<ICollection<PersonajeDtoForDisplay>> GetAll();
        Task<Result> GetById(int id);
        Task<Result> Insert(PersonajeDtoForInsert personajeDto);
        Task<Result> Update(int id, PersonajeDtoForInsert dto);
    }
}
