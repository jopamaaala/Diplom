using Informatika.Database;
using Informatika.Domain.Models;
using Informatika.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Informatika.Repository.Repositories
{
    public class LectionsRepository : ILectionsRepository
    {
        private readonly InformatikaDbContext _context;

        public LectionsRepository(InformatikaDbContext context)
        {
            _context = context;
        }

        public async Task<Lection?> GetLectionByIdAsync(Guid id)
        {
            return await _context.Lections
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Lection>> GetLectionsListAsync()
        {
            return await _context.Lections
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Lection>> SearchLections(string query)
        {
            return await _context.Lections
            .AsNoTracking()
            .Where(l =>
                EF.Functions.Like(
                    l.Title,
                    $"%{query}%"))
            .ToListAsync();
        }

        public async Task AddLectionAsync(Lection lection)
        {
            _context.Lections
                .Add(lection);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteLectionAsync(Lection lection)
        {
            _context.Lections
                .Remove(lection);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateLectionAsync(Lection lection)
        {
            _context.Lections
                .Update(lection);

            await _context
                .SaveChangesAsync();
        }
    }
}