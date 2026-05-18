using Informatika.Domain.Models;

namespace Informatika.Repository.Interfaces
{
    public interface ILectionTasksRepository
    {
        Task AddLectionTaskAsync(LectionTask lectionTask);
        Task DeleteLectionTaskAsync(LectionTask lectionTask);
        Task<LectionTask?> GetLectionTaskByIdAsync(Guid id);
        Task<List<LectionTask>> GetLectionTasksListAsync();
        Task UpdateLectionTaskAsync(LectionTask lectionTask);
    }
}