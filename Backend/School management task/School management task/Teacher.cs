using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public class Teacher : IGetBonus, IDetails
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Subject { get; set; }
        public double Salary { get; set; }
        public Teacher(string id, string name, string phone, string subject, double salary)
        {
            ID = id;
            Name = name;
            Phone_Number = phone;
            Subject = subject;
            Salary = salary;
        }

        public Teacher()
        {
        }

        public async Task<double> GetBonus()
        {
            await Task.Delay(2000);
            return Salary * 0.10;
        }

        public async Task Details(string teacherId)
        {
             if (TeacherData.teacherData.ContainsKey(teacherId))
            {
                Teacher teacher = TeacherData.teacherData[teacherId];
                Console.WriteLine($"Teacher ID: {teacher.ID}");
                Console.WriteLine($"Name: {teacher.Name}");
                Console.WriteLine($"Phone Number: {teacher.Phone_Number}");
                Console.WriteLine($"Subject: {teacher.Subject}");
                Console.WriteLine($"Salary: Rs.{teacher.Salary}");
                double bonus = await teacher.GetBonus();
                Console.WriteLine($"Bonus: Rs.{bonus}");

                Console.WriteLine("---------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"No teacher found with ID {teacherId}");
            }
        }
    }
}
