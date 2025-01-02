using Core.DTOs.Product;

namespace Core.DTOs.OrderDetail
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public float UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public ProductListDto? Product { get; set; }
    }
}
