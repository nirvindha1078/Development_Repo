using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria_task
{
    public delegate void OrderPreparationDelegate(string drinkType, string size, string milkType, int sugar, string additionalOptions);

    public class Order
    {
        public event Action OrderPrepared;

        public void PrepareOrder(string drinkType, string size, string milkType, int sugar, string additionalOptions)
        {
            Console.WriteLine($"Preparing your {drinkType}...");
            Console.WriteLine($"Size: {size}");
            Console.WriteLine($"Milk Type: {milkType}");
            Console.WriteLine($"Sugar: {sugar} tablespoons");
            Console.WriteLine($"Additional options: {additionalOptions}");

            System.Threading.Thread.Sleep(2000);  

            OnOrderPrepared();
        }

        public virtual void OnOrderPrepared()
        {
            if (OrderPrepared != null)
            {
                OrderPrepared.Invoke();
            }
        }
    }
}
