using System;
using Cafetaria_task;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Cafeteria");

        while (true)
        {
            Console.WriteLine("Choose any:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Exit");

            try
            {
                int role = int.Parse(Console.ReadLine().Trim().ToLower());

                switch (role)
                {
                    case 1:
                        Admin admin = new Admin();
                        admin.Login();
                        break;

                    case 2:
                        User user = new User();
                        user.Checkout();
                        break;

                    case 3:
                        Console.WriteLine("Exiting the program...");
                        return;  

                    default:
                        Console.WriteLine("Invalid option. Please choose '1' for Admin, '2' for User, or '3' to Exit.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
