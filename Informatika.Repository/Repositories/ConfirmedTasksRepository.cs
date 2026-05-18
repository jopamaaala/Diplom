using Informatika.Database;
using Informatika.Domain.Models;
using Informatika.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Informatika.Repository.Repositories
{
    public class ConfirmedTasksRepository : IConfirmedTasksRepository
    {
        private readonly InformatikaDbContext _context;

        public ConfirmedTasksRepository(InformatikaDbContext context)
        {
            _context = context;
        }

        public async Task<ConfirmedTask?> GetConfirmedTaskByIdAsync(Guid id)
        {
            return await _context.ConfirmedTasks
                .AsNoTracking()
                .FirstOrDefaultAsync(ct => ct.Id == id);
        }

        public async Task<List<ConfirmedTask>> GetConfirmedTasksListAsync()
        {
            return await _context.ConfirmedTasks
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddConfirmedTaskAsync(ConfirmedTask confirmedTask)
        {
            _context.ConfirmedTasks
                .Add(confirmedTask);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteConfirmedTaskAsync(ConfirmedTask confirmedTask)
        {
            _context.ConfirmedTasks
                .Remove(confirmedTask);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateConfirmedTaskAsync(ConfirmedTask confirmedTask)
        {
            _context.ConfirmedTasks
                .Update(confirmedTask);

            await _context
                .SaveChangesAsync();
        }
    }
}