using Core.Models;

namespace Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllWithCategoryAndSupplierAsync();
        Task<Product> GetByIdWithCategoryAndSupplierAsync(int id);
    }
}
