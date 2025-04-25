using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria_task
{
    public class Admin
    {
        public void Login()
        { 
            Console.WriteLine("Enter Admin username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Admin password:");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("Login successful! Here are the user profiles:");
                ViewUserProfiles();
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
        }

        public void ViewUserProfiles()
        {
            if (UserProfile.UserProfiles.Count == 0)
            {
                Console.WriteLine("No user profiles available.");
            }
            else
            {
                for (int i = 0; i < UserProfile.UserProfiles.Count; i++)
                {
                    var profile = UserProfile.UserProfiles[i];
                    Console.WriteLine($"\nUser {i + 1}:");
                    Console.WriteLine($"Name: {profile.Name}");
                    Console.WriteLine($"Phone: {profile.PhoneNumber}");
                    Console.WriteLine($"Email: {profile.Email}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }
    }
}
