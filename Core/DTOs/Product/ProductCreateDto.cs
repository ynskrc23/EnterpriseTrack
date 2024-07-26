using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Product
{
    public class ProductCreateDto : BaseDto
    {
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public float? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public int Discontinued { get; set; }
    }
}
