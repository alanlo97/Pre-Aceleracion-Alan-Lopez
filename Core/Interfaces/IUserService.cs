using Challenge.Core.Models.Dtos;
using Challenge.Core.Models.Response;
using System.Threading.Tasks;

namespace Challenge.Core.Interfaces
{
    public interface IUserService
    {
        Task<Result> Insert(UserRegisterDto dto);
        Task<Result> LoginAsync(UserLoginDTO userLoginDto);
    }
}
