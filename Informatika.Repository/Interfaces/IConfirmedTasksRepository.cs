using Informatika.Domain.Models;

namespace Informatika.Repository.Interfaces
{
    public interface IConfirmedTasksRepository
    {
        Task AddConfirmedTaskAsync(ConfirmedTask confirmedTask);
        Task DeleteConfirmedTaskAsync(ConfirmedTask confirmedTask);
        Task<ConfirmedTask?> GetConfirmedTaskByIdAsync(Guid id);
        Task<List<ConfirmedTask>> GetConfirmedTasksListAsync();
        Task UpdateConfirmedTaskAsync(ConfirmedTask confirmedTask);
    }
}