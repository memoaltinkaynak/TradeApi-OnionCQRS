﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeApi.Domain.Common;

namespace TradeApi.Domain
{
    public class Product : EntityBase
    {
        public Product() 
        {
        
        }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BrandId { get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set;}

        public Brand Brand { get; set; }
        public ICollection<Category> Categories { get; set; }
        //public required string ImagePath { get; set;}
    }
}
