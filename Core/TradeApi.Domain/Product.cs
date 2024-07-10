using System;
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

        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set;}

        public Brand Brand { get; set; }
        public ICollection<Category> Categories { get; set; }
        //public required string ImagePath { get; set;}
    }
}
