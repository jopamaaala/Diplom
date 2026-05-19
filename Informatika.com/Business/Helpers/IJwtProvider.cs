using Informatika.Domain.Models;

namespace Informatika.Application.Business.Helpers
{
    public interface IJwtProvider
    {
        string GenerateToken(User User);
    }
}