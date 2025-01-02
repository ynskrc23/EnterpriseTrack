using Core.DTOs.OrderDetail;

namespace Core.DTOs.Order
{
    public class OrderUpdateDto : BaseDto
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
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}
