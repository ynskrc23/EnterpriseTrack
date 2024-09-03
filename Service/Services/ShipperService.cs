using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ShipperService : Service<Shipper>, IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public ShipperService(IGenericRepository<Shipper> repository, IUnitOfWork unitOfWork, IMapper mapper, IShipperRepository shipperRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _shipperRepository = shipperRepository;
        }
    }
}
