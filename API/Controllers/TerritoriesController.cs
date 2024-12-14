using AutoMapper;
using Core.DTOs.Territory;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.Models;

namespace API.Controllers
{
    public class TerritoriesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ITerritoryService _service;

        public TerritoriesController(IMapper mapper, ITerritoryService TerritoryService)
        {

            _mapper = mapper;
            _service = TerritoryService;
        }

        /// GET api/territories
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Territorys = await _service.GetAllAsync();
            var TerritorysDtos = _mapper.Map<List<TerritoryListDto>>(Territorys.ToList());
            return CreateActionResult(CustomResponseDto<List<TerritoryListDto>>.Success(200, TerritorysDtos));
        }

        // GET /api/territories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Territory = await _service.GetByIdAsync(id);
            var TerritorysDto = _mapper.Map<TerritoryListDto>(Territory);
            return CreateActionResult(CustomResponseDto<TerritoryListDto>.Success(200, TerritorysDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TerritoryCreateDto TerritoryDto)
        {
            var Territory = await _service.AddAsync(_mapper.Map<Territory>(TerritoryDto));
            var TerritorysDto = _mapper.Map<TerritoryCreateDto>(Territory);
            return CreateActionResult(CustomResponseDto<TerritoryCreateDto>.Success(201, TerritorysDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TerritoryUpdateDto TerritoryDto)
        {
            await _service.UpdateAsync(_mapper.Map<Territory>(TerritoryDto));
            return CreateActionResult(CustomResponseDto<TerritoryUpdateDto>.Success(204));
        }

        // DELETE api/territories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Territory = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Territory);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
