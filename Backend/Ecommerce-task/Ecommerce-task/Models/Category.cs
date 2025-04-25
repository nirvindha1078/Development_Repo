using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_task.Models
{
    public struct Category
    {
        public string Name;
        public List<Product> Products;

        public Category(string name)
        {
            Name = name;
            Products = new List<Product>();
        }
    }
}
