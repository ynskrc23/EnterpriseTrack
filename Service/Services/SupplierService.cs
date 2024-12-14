using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class SupplierService : Service<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(IGenericRepository<Supplier> repository, IUnitOfWork unitOfWork, IMapper mapper, ISupplierRepository supplierRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
    }
}
