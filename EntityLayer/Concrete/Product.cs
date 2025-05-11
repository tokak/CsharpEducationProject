﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public List<Order> Orders { get; set; }
    }
}
