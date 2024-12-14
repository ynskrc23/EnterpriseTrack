using Core.Models;

namespace Core.Repositories
{
    public interface ITerritoryRepository : IGenericRepository<Territory>
    {
        Task<List<Territory>> GetAllWithRegionAsync();
        Task<Territory> GetByIdWithRegionAsync(int id);
    }
}
