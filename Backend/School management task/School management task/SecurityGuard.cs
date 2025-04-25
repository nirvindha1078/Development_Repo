using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public class SecurityGuard : IGetBonus, IDetails
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public double Salary { get; set; }
        public SecurityGuard(string id, string name, string phone, double salary)
        {
            ID = id;
            Name = name;
            Phone_Number = phone;
            Salary = salary;
        }

        public SecurityGuard()
        {
        }

        public async Task<double> GetBonus()
        {
            await Task.Delay(2000);
            return Salary * 0.02;
        }

        public async Task Details(string securityId)
        {
            if (SecurityGuardData.securityGuardData.ContainsKey(securityId))
            {
                SecurityGuard security = SecurityGuardData.securityGuardData[securityId];
                Console.WriteLine($"Security Guard ID: {security.ID}");
                Console.WriteLine($"Name: {security.Name}");
                Console.WriteLine($"Phone Number: {security.Phone_Number}");
                Console.WriteLine($"Salary: Rs.{security.Salary}");
                double bonus = await security.GetBonus();
                Console.WriteLine($"Bonus: Rs.{bonus}");

                Console.WriteLine("---------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"No security guard found with ID {securityId}");
            }
        }
    }

}
