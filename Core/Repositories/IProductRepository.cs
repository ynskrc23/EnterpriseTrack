﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllWithCategoryAndSupplierAsync();
        Task<Product> GetByIdWithCategoryAndSupplierAsync(int id);
    }
}
