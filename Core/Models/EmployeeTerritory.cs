using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class EmployeeTerritory : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int TerritoryId { get; set; }

        public Employee Employee { get; set; }
        public Territory Territory { get; set; }
    }
}
