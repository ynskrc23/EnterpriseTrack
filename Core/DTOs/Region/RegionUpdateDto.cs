using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Region
{
    public class RegionUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public string RegionDescription { get; set; }
    }
}
