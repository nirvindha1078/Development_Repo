using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public class Admin
    {
        public bool Authenticate(string username, string password)
        {
            return username == "admin" && password == "password";
        }

        public void AddProfession()
        {
            while (true)
            {
                Console.WriteLine("Select Profession to add:");
                Console.WriteLine("1. Teacher");
                Console.WriteLine("2. Student");
                Console.WriteLine("3. Security Guard");
                Console.WriteLine("4. Lab Assistant");
                Console.WriteLine("5. Exit");

                int input;
                bool validInput = int.TryParse(Console.ReadLine(), out input);

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (input)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        AddSecurityGuard();
                        break;
                    case 4:
                        AddLabAssistant();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }

        private void AddTeacher()
        {
            Console.WriteLine("Enter the ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the subject taught:");
            string subject = Console.ReadLine();
            Console.WriteLine("Enter the salary:");

            double salary;
            bool validSalary = double.TryParse(Console.ReadLine(), out salary);

            if (!validSalary)
            {
                Console.WriteLine("Invalid salary input. Please enter a valid number.");
                return;
            }

            Teacher teacherObj = new Teacher(id, name, phone, subject, salary);
            DataBase.AddTeacherData(teacherObj);
        }

        private void AddStudent()
        {
            Console.WriteLine("Enter the ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the subject enrolled:");
            string subject = Console.ReadLine();

            Student studentObj = new Student(id, name, phone, subject);
            DataBase.AddStudentData(studentObj);
        }
        private void AddSecurityGuard()
        {
            Console.WriteLine("Enter the ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the salary:");

            double salary;
            bool validSalary = double.TryParse(Console.ReadLine(), out salary);

            if (!validSalary)
            {
                Console.WriteLine("Invalid salary input. Please enter a valid number.");
                return;
            }

            SecurityGuard securityObj = new SecurityGuard(id, name, phone, salary);
            DataBase.AddSecurityGuardData(securityObj);
        }

        private void AddLabAssistant()
        {
            Console.WriteLine("Enter the ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the salary:");

            double salary;
            bool validSalary = double.TryParse(Console.ReadLine(), out salary);

            if (!validSalary)
            {
                Console.WriteLine("Invalid salary input. Please enter a valid number.");
                return;
            }

            LabAssistant labObj = new LabAssistant(id, name, phone, salary);
            DataBase.AddLabAssistantData(labObj);
        }
    }
}
