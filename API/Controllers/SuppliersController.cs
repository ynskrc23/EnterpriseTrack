using AutoMapper;
using Core.DTOs.Supplier;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.Models;

namespace API.Controllers
{
    public class SuppliersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _service;

        public SuppliersController(IMapper mapper, ISupplierService supplierService)
        {

            _mapper = mapper;
            _service = supplierService;
        }

        /// GET api/suppliers
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var suppliers = await _service.GetAllAsync();
            var suppliersDtos = _mapper.Map<List<SupplierListDto>>(suppliers.ToList());
            return CreateActionResult(CustomResponseDto<List<SupplierListDto>>.Success(200, suppliersDtos));
        }

        // GET /api/suppliers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _service.GetByIdAsync(id);
            var suppliersDto = _mapper.Map<SupplierListDto>(supplier);
            return CreateActionResult(CustomResponseDto<SupplierListDto>.Success(200, suppliersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SupplierCreateDto supplierDto)
        {
            var supplier = await _service.AddAsync(_mapper.Map<Supplier>(supplierDto));
            var suppliersDto = _mapper.Map<SupplierCreateDto>(supplier);
            return CreateActionResult(CustomResponseDto<SupplierCreateDto>.Success(201, suppliersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SupplierUpdateDto supplierDto)
        {
            await _service.UpdateAsync(_mapper.Map<Supplier>(supplierDto));
            return CreateActionResult(CustomResponseDto<SupplierUpdateDto>.Success(204));
        }

        // DELETE api/suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var supplier = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(supplier);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
