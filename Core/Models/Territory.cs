using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Territory : BaseEntity
    {
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
    }
}
