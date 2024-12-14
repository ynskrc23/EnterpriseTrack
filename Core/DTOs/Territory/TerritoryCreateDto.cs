using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Territory
{
    public class TerritoryCreateDto : BaseDto
    {
        public string TerritoryDescription { get; set; }
        public int? RegionId { get; set; }
    }
}
