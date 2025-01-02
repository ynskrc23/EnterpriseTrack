using Core.DTOs.Customer;
using Core.DTOs.Employee;
using Core.DTOs.OrderDetail;
using Core.DTOs.Shipper;

namespace Core.DTOs.Order
{
    public class OrderListDto : BaseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShipperId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public short? ShipVia { get; set; }
        public float? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public CustomerListDto? Customer {  get; set; }
        public EmployeeListDto? Employee { get; set; }
        public ShipperListDto? Shipper { get; set; }
        public List<OrderDetailDto>? Details { get; set; }
    }
}
