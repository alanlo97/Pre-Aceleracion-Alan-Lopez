using Challenge.Core.Models.Dtos;
using Challenge.Core.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Core.Interfaces
{
    public interface IGeneroService
    {
        Task<Result> Delete(int id);
        Task<ICollection<GeneroDto>> GetAll();
        Task<Result> Insert(GeneroDto generoDto);
    }
}
