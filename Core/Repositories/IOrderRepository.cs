using Core.Models;

namespace Core.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetAllWithOrderDetailsAsync();
        Task<Order> GetByIdWithOrderDetailsAsync(int id);
    }
}
