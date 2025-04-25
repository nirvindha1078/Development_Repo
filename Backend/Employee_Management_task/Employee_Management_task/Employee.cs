using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_task
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string name, string role, double salary)
        {
            ID = id;
            Name = name;
            Role = role;
            Salary = salary;
        }

        //public override string ToString()
        //{
        //    return $"ID: {ID}, Name: {Name}, Role: {Role}, Salary: Rs.{Salary}";
        //}
    }

}
