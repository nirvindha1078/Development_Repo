using System;
using System.Collections.Generic;
using static School_management_task.DataBase;
using System.Threading.Tasks;
using School_management_task;

public class Program
{
    static async Task Main(string[] args)
    {
        var admin = new Admin();
        int userType;
        while (true)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.User");
            Console.WriteLine("3.Exit");
            userType = int.Parse(Console.ReadLine());

            if (userType == 1)
            {
                Console.WriteLine("Enter Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string password = Console.ReadLine();

                if (admin.Authenticate(username, password))
                {
                    Console.WriteLine("Welcome Admin.");
                    admin.AddProfession();
                }
                else
                {
                    Console.WriteLine("Invalid credentials.");
                }
            }
            else if (userType == 2)
            {
                while (true)
                {
                    Console.WriteLine("1.Teacher");
                    Console.WriteLine("2.Student");
                    Console.WriteLine("3.Secuirty Guard");
                    Console.WriteLine("4.Lab Assistant");
                    Console.WriteLine("5.Exit");

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
                            Console.WriteLine("Enter your ID:");
                            string Tid = Console.ReadLine();
                            Teacher t = new Teacher();
                            await t.Details(Tid);
                            break;
                        case 2:
                            Console.WriteLine("Enter your ID:");
                            string Sid = Console.ReadLine();
                            Student s = new Student();
                            await s.Details(Sid);
                            break;
                        case 3:
                            Console.WriteLine("Enter your ID:");
                            string Secid = Console.ReadLine();
                            SecurityGuard sec = new SecurityGuard();
                            await sec.Details(Secid);
                            break;
                        case 4:
                            Console.WriteLine("Enter your ID:");
                            string labid = Console.ReadLine();
                            LabAssistant l = new LabAssistant();
                            await l.Details(labid);
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            break;
                    }
                
                }

            }
            else
            {
                return;
            }
        }
    }
}