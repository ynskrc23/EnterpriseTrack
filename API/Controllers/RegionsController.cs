using AutoMapper;
using Core.DTOs.Region;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RegionsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IRegionService _service;

        public RegionsController(IMapper mapper, IRegionService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// GET api/Regions
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Regions = await _service.GetAllAsync();
            var RegionsDtos = _mapper.Map<List<RegionListDto>>(Regions.ToList());
            return CreateActionResult(CustomResponseDto<List<RegionListDto>>.Success(200, RegionsDtos));
        }

        // GET /api/Regions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Region = await _service.GetByIdAsync(id);
            var RegionsDto = _mapper.Map<RegionListDto>(Region);
            return CreateActionResult(CustomResponseDto<RegionListDto>.Success(200, RegionsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(RegionCreateDto RegionDto)
        {
            var Region = await _service.AddAsync(_mapper.Map<Region>(RegionDto));
            var RegionsDto = _mapper.Map<RegionCreateDto>(Region);
            return CreateActionResult(CustomResponseDto<RegionCreateDto>.Success(201, RegionsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(RegionUpdateDto RegionDto)
        {
            await _service.UpdateAsync(_mapper.Map<Region>(RegionDto));
            return CreateActionResult(CustomResponseDto<RegionUpdateDto>.Success(204));
        }

        // DELETE api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Region = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Region);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
