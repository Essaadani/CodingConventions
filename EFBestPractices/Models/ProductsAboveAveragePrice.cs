﻿using System;
using System.Collections.Generic;

namespace EFBestPractices.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
