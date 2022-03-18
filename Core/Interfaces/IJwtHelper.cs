using Challenge.Entities;

namespace Challenge.Core.Interfaces
{
    public interface IJwtHelper
    {
        string GenerateJwtToken(User user);
    }
}
