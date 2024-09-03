using AutoMapper;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs.Shipper;
using Core.Models;

namespace API.Controllers
{
    public class ShippersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IShipperService _service;

        public ShippersController(IMapper mapper, IShipperService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// GET api/shippers
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var shippers = await _service.GetAllAsync();
            var shippersDtos = _mapper.Map<List<ShipperListDto>>(shippers.ToList());
            return CreateActionResult(CustomResponseDto<List<ShipperListDto>>.Success(200, shippersDtos));
        }

        // GET /api/shippers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shipper = await _service.GetByIdAsync(id);
            var shippersDto = _mapper.Map<ShipperListDto>(shipper);
            return CreateActionResult(CustomResponseDto<ShipperListDto>.Success(200, shippersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ShipperCreateDto shipperDto)
        {
            var shipper = await _service.AddAsync(_mapper.Map<Shipper>(shipperDto));
            var shippersDto = _mapper.Map<ShipperCreateDto>(shipper);
            return CreateActionResult(CustomResponseDto<ShipperCreateDto>.Success(201, shippersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ShipperUpdateDto shipperDto)
        {
            await _service.UpdateAsync(_mapper.Map<Shipper>(shipperDto));
            return CreateActionResult(CustomResponseDto<ShipperUpdateDto>.Success(204));
        }

        // DELETE api/shippers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var shipper = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(shipper);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
