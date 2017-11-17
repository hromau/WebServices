using System;
using System.Collections.Generic;

namespace WebServices
{
    public partial class UserTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string GroupName { get; set; }
    }
}
