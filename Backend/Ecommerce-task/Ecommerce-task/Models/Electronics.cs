using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_task.Models
{
    public class Electronics : Product
    {
        public Electronics(string name, decimal price, string description, int stock)
            : base(name, price, description, stock) { }

        public override decimal CalculateDiscount()
        {
            return Price - (Price * 0.10m);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Category: Electronics");
        }
    }
}
