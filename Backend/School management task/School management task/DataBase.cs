using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public class DataBase()
    {
        public static void AddTeacherData(Teacher teacher)
        {
            if (!TeacherData.teacherData.ContainsKey(teacher.ID))
            {
                TeacherData.teacherData.Add(teacher.ID, teacher);
                Console.WriteLine($"Teacher {teacher.Name} with ID {teacher.ID} added successfully.");
                Console.WriteLine("---------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"Teacher with ID {teacher.ID} already exists.");
            }
        }

        public static void AddStudentData(Student student)
        {
            if (!StudentData.studentData.ContainsKey(student.ID))
            {
                StudentData.studentData.Add(student.ID, student);
                Console.WriteLine($"Student {student.Name} with ID {student.ID} added successfully.");

            }
            else
            {
                Console.WriteLine($"Student with ID {student.ID} already exists.");
            }
        }

        public static void AddSecurityGuardData(SecurityGuard security)
        {
            if (!SecurityGuardData.securityGuardData.ContainsKey(security.ID))
            {
                SecurityGuardData.securityGuardData.Add(security.ID, security);
                Console.WriteLine($"Security Guard {security.Name} with ID {security.ID} added successfully.");
            }
            else
            {
                Console.WriteLine($"Security Guard with ID {security.ID} already exists.");
            }
        }

        public static void AddLabAssistantData(LabAssistant lab)
        {
            if (!LabAssistantData.labAssistantData.ContainsKey(lab.ID))
            {
                LabAssistantData.labAssistantData.Add(lab.ID, lab);
                Console.WriteLine($"Lab Assistant {lab.Name} with ID {lab.ID} added successfully.");
            }
            else
            {
                Console.WriteLine($"Lab Assistant with ID {lab.ID} already exists.");
            }
        }
    }
}
