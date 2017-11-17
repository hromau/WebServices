using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebServices
{
    public class UserTable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string GroupName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Default construct
        /// </summary>
        public UserTable()
        {

        }

        /// <summary>
        /// Construct with parametrs
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="accountNumber">accountNumber</param>
        /// <param name="email">email</param>
        /// <param name="dob">dob</param>
        /// <param name="groupName">groupName</param>
        /// <param name="password">password</param>
        public UserTable(string firstName, string lastName, string accountNumber, string email, DateTime dob,string groupName, string password)
        {
            FirstName = firstName;
            AccountNumber = accountNumber;
            LastName = lastName;
            AccountNumber = accountNumber;
            Email = email;
            DOB = dob;
            GroupName = groupName;
            Password = password;
        }
    }
}
