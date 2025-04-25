using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria_task
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public static List<UserProfile> UserProfiles = new List<UserProfile>();
        public UserProfile(string name, string phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
    //public  static class UserProfileStorage
    //{
    //}

}
