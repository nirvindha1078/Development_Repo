using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_task.Models;

namespace Ecommerce_task.Interfaces
{
    public interface IAdminActions
    {
        void AddProduct(Category category, Product product);
        void RemoveProduct(Category category, string productName);
        void UpdateProductDetails(Category category, string productName, string newDescription, decimal newPrice, int newStock);
    }
}
