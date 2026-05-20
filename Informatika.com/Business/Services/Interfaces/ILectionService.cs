using Informatika.Application.Models.Requests;
using Informatika.Domain.Models;

namespace Informatika.Application.Business.Services
{
    public interface ILectionService
    {
        Task<ServiceResponse<Lection>> AddAsync(LectionUpdateRequest request);
        Task<ServiceResponse<Lection>> DeleteAsync(Guid Id);
        Task<ServiceResponse<List<Lection>>> GetAllAsync();
        Task<ServiceResponse<Lection>> GetByIdAsync(Guid LectionId);
        Task<ServiceResponse<List<Lection>>> SearchAsync(string query);
        Task<ServiceResponse<Lection>> UpdateLectionAsync(Guid LectionId, LectionUpdateRequest request);
    }
}