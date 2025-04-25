using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public class LabAssistant : IDetails, IGetBonus
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public double Salary { get; set; }
        public LabAssistant(string id, string name, string phone, double salary)
        {
            ID = id;
            Name = name;
            Phone_Number = phone;
            Salary = salary;
        }

        public LabAssistant()
        {
        }

        public async Task<double> GetBonus()
        {
            await Task.Delay(2000);
            return Salary * 0.05;
        }

        public async Task Details(string labId)
        {
            
            if (LabAssistantData.labAssistantData.ContainsKey(labId))
            {
                LabAssistant lab = LabAssistantData.labAssistantData[labId];
                Console.WriteLine($"Lab Assistant ID: {lab.ID}");
                Console.WriteLine($"Name: {lab.Name}");
                Console.WriteLine($"Phone Number: {lab.Phone_Number}");
                Console.WriteLine($"Salary: Rs.{lab.Salary}");
                double bonus = await lab.GetBonus();
                Console.WriteLine($"Bonus: Rs.{bonus}");

                Console.WriteLine("---------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"No lab assistant found with ID {labId}");
            }
        }
    }

}
