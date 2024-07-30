﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Category
{
    public class CategoryCreateDto : BaseDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
