using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_task.Models
{
    public abstract class Product
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; private set; }

        public Product(string name, decimal price, string description, int stock)
        {
            Name = name;
            Price = price;
            Description = description;
            Stock = stock;
        }

        public abstract decimal CalculateDiscount();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: ₹{Price}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Discounted Price: ₹{CalculateDiscount()}");
            Console.WriteLine($"Stock: {Stock}");
        }

        public bool BuyProduct(int quantity, out decimal totalCost)
        {
            totalCost = 0;
            if (quantity <= Stock)
            {
                Stock -= quantity;
                totalCost = CalculateDiscount() * quantity;
                return true;
            }
            return false;
        }

        public void UpdateStock(int newStock)
        {
            Stock = newStock;
        }
    }
}
