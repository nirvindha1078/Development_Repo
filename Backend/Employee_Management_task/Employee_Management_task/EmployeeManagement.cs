using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_task
{
    public class EmployeeManagement
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            if (employees.Any(e => e.ID == employee.ID))
            {
                throw new DuplicateEmployeeException("An employee with this ID already exists.");
            }

            if (employee.Salary < 0)
            {
                throw new InvalidSalaryException("Salary cannot be negative.");
            }

            employees.Add(employee);
            Console.WriteLine("Employee added successfully.");
        }

        public void RemoveEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.ID == id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException("Employee not found.");
            }

            employees.Remove(employee);
            Console.WriteLine("Employee removed successfully.");
        }

        public Employee SearchEmployee(string name)
        {
            var employee = employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (employee == null)
            {
                throw new EmployeeNotFoundException("Employee not found.");
            }

            return employee;
        }

        public double CalculateTotalSalaries()
        {
            return employees.Sum(e => e.Salary);
        }

        public void DisplayAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.ID}, Name: {employee.Name}, Role: {employee.Role}, Salary: Rs.{employee.Salary}");
            }
        }

        public void SortEmployeesBySalary(bool ascending = true)
        {
            if (ascending)
            {
                employees = employees.OrderBy(e => e.Salary).ToList();
            }
            else
            {
                employees = employees.OrderByDescending(e => e.Salary).ToList();
            }

            Console.WriteLine("Employees sorted by salary.");
        }
    }
}
