using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models
{
    public class PersonalInformation
    {
        
        public int PersonalInformationId { get; set; }
       
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool SendNotifications { get; set; }

        public Player Player { get; set; }
              
    }
}
