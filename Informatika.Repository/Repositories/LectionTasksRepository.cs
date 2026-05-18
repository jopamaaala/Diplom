using Informatika.Database;
using Informatika.Domain.Models;
using Informatika.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Informatika.Repository.Repositories
{
    public class LectionTasksRepository : ILectionTasksRepository
    {
        private readonly InformatikaDbContext _context;

        public LectionTasksRepository(InformatikaDbContext context)
        {
            _context = context;
        }

        public async Task<LectionTask?> GetLectionTaskByIdAsync(Guid id)
        {
            return await _context.LectionTasks
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id);
        }

        public async Task<List<LectionTask>> GetLectionTasksListAsync()
        {
            return await _context.LectionTasks
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddLectionTaskAsync(LectionTask lectionTask)
        {
            _context.LectionTasks
                .Add(lectionTask);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteLectionTaskAsync(LectionTask lectionTask)
        {
            _context.LectionTasks
                .Remove(lectionTask);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateLectionTaskAsync(LectionTask lectionTask)
        {
            _context.LectionTasks
                .Update(lectionTask);

            await _context
                .SaveChangesAsync();
        }
    }
}