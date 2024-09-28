using AutoMapper;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs.Customer;
using Core.Models;

namespace API.Controllers
{
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {

            _mapper = mapper;
            _service = customerService;
        }

        /// GET api/customers
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _service.GetAllAsync();
            var customersDtos = _mapper.Map<List<CustomerListDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerListDto>>.Success(200, customersDtos));
        }

        // GET /api/customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            var customersDto = _mapper.Map<CustomerListDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerListDto>.Success(200, customersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerCreateDto customerDto)
        {
            var customer = await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            var customersDto = _mapper.Map<CustomerCreateDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerCreateDto>.Success(201, customersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));
            return CreateActionResult(CustomResponseDto<CustomerUpdateDto>.Success(204));
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customer);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
