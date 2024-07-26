using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Order : BaseEntity
    {
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

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Shipper Shipper { get; set; }
    }
}
