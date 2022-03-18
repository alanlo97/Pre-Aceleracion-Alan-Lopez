using Challenge.Core.Models.Dtos;
using Challenge.Core.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Core.Interfaces
{
    public interface IPeliculaSerieService
    {
        Task<Result> Delete(int id);
        Task<ICollection<PeliculaSerieDtoForDisplay>> GetAll();
        Task<Result> GetById(int id);
        Task<Result> Insert(PeliculaSerieDtoForInsert peliculaSerieDto);
        Task<Result> Update(int id, PeliculaSerieDtoForInsert dto);
    }
}
