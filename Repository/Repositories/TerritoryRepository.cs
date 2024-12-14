using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class TerritoryRepository : GenericRepository<Territory>, ITerritoryRepository
    {
        public TerritoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Territory>> GetAllWithRegionAsync()
        {
            return await _context.Territories
                .Include(p => p.Region)
                .ToListAsync();
        }

        public async Task<Territory> GetByIdWithRegionAsync(int id)
        {
            return await _context.Territories
                 .Include(p => p.Region)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
