using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeApi.Domain.Common;

namespace TradeApi.Domain
{
    public class Brand : EntityBase
    {
        public Brand() { }

        public Brand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
