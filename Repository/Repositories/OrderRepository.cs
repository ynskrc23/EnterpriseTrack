using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetAllWithOrderDetailsAsync()
        {
            return await _context.Orders
                .Include(p => p.Customer)
                .Include(p => p.Employee)
                .Include(p => p.Shipper)
                .Include(p => p.Details)
                .ThenInclude(p => p.Product)
                .ToListAsync();
        }

        public async Task<Order> GetByIdWithOrderDetailsAsync(int id)
        {
            return await _context.Orders
                .Include(p => p.Customer)
                .Include(p => p.Employee)
                .Include(p => p.Shipper)
                .Include(p => p.Details)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
