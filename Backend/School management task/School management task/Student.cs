using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Subject { get; set; }
        public Student(string id, string name, string phone, string subject)
        {
            ID = id;
            Name = name;
            Phone_Number = phone;
            Subject = subject;
        }

        public Student()
        {
        }

        public async Task Details(string studentId)
        {
            if (StudentData.studentData.ContainsKey(studentId))
            {
                Student student = StudentData.studentData[studentId];
                Console.WriteLine($"Student ID: {student.ID}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Phone Number: {student.Phone_Number}");
                Console.WriteLine($"Course Enrolled: {student.Subject}");
                Console.WriteLine("---------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"No student found with ID {studentId}");
            }
        }

    }
}
