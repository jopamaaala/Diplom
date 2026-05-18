using Informatika.Domain.Models;

namespace Informatika.Repository.Interfaces
{
    public interface ILectionsRepository
    {
        Task AddLectionAsync(Lection lection);
        Task DeleteLectionAsync(Lection lection);
        Task<Lection?> GetLectionByIdAsync(Guid id);
        Task<List<Lection>> GetLectionsListAsync();
        Task UpdateLectionAsync(Lection lection);
    }
}