using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class TerritoryService : Service<Territory>, ITerritoryService
    {
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IMapper _mapper;

        public TerritoryService(IGenericRepository<Territory> repository, IUnitOfWork unitOfWork, IMapper mapper, ITerritoryRepository territoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
        }

        public async Task<IEnumerable<Territory>> GetAllAsync()
        {
            return await _territoryRepository.GetAllWithRegionAsync();
        }
        public async Task<Territory> GetByIdAsync(int id)
        {
            return await _territoryRepository.GetByIdWithRegionAsync(id);
        }
    }
}
