using AutoMapper;
using Core.DTOs.Order;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.Models;

namespace API.Controllers
{
    public class OrdersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _service;

        public OrdersController(IMapper mapper, IOrderService service)
        {

            _mapper = mapper;
            _service = service;
        }

        /// GET api/orders
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orders = await _service.GetAllAsync();
            var ordersDtos = _mapper.Map<List<OrderListDto>>(orders.ToList());
            return CreateActionResult(CustomResponseDto<List<OrderListDto>>.Success(200, ordersDtos));
        }

        // GET /api/orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetByIdAsync(id);
            var ordersDto = _mapper.Map<OrderListDto>(order);
            return CreateActionResult(CustomResponseDto<OrderListDto>.Success(200, ordersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderCreateDto orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto);
            var createdOrder = await _service.AddAsync(orderEntity);
            var createdOrderDto = _mapper.Map<OrderCreateDto>(createdOrder);
            return CreateActionResult(CustomResponseDto<OrderCreateDto>.Success(201, createdOrderDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdateDto orderDto)
        {
            // Veritabanından güncellenecek siparişi bul
            var existingOrder = await _service.GetByIdAsync(orderDto.Id);
            if (existingOrder == null)
                return NotFound(CustomResponseDto<NoContentDto>.Fail(404, "Sipariş bulunamadı"));

            // DTO'dan gelen verilerle mevcut siparişi güncelle
            _mapper.Map(orderDto, existingOrder);
         
            // Güncellenmiş siparişi veritabanına kaydet
            await _service.UpdateAsync(existingOrder);

            // Güncellenmiş veriyi DTO'ya dönüştürüp yanıt olarak döner
            var updatedOrderDto = _mapper.Map<OrderUpdateDto>(existingOrder);
            return CreateActionResult(CustomResponseDto<OrderUpdateDto>.Success(200, updatedOrderDto));
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var order = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(order);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
