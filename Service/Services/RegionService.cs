using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class RegionService : Service<Region>, IRegionService
    {
        private readonly IRegionRepository _RegionRepository;
        private readonly IMapper _mapper;

        public RegionService(IGenericRepository<Region> repository, IUnitOfWork unitOfWork, IMapper mapper, IRegionRepository RegionRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _RegionRepository = RegionRepository;
        }
    }
}
