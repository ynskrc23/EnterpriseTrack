﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Shipper
{
    public class ShipperCreateDto : BaseDto
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
