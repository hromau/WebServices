using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    public class ModelActiveUser:IActiveUser
    {
        public string firstName;
        public string lastName;
        public string accountNumber;
        public string email;
        public DateTime dob;
        public string groupName;

        public ModelActiveUser(string accountNumber)
        {
            firstName = Startup.item.UserTable.Where(it => it.AccountNumber.Equals(accountNumber)).ToString();
            lastName = Startup.item.UserTable.Where(it => it.AccountNumber.Equals(accountNumber)).ToString();
            accountNumber = Startup.item.UserTable.Where(it => it.AccountNumber.Equals(accountNumber)).ToString();
            email = Startup.item.UserTable.Where(it => it.AccountNumber.Equals(accountNumber)).ToString();
            dob = Convert.ToDateTime(Startup.item.UserTable.Where(it => it.AccountNumber.Equals(accountNumber)));
            groupName = Startup.item.UserTable.Where(it => it.AccountNumber.Equals(accountNumber)).ToString();

        }

        public string FirstName => firstName;

        public string LastName => lastName;

        public string AccountNumber => accountNumber;

        public string Email => email;

        public DateTime DOB => dob;

        public string GroupName => groupName;

        public void SetModel(ModelActiveUser modelActiveUser)
        {
            //firstName = modelActiveUser.firstName;
            //lastName = modelActiveUser.lastName;
            //accountNumber = modelActiveUser.accountNumber;
            //email = modelActiveUser.email;
            //dob = modelActiveUser.dob;
            //groupName = modelActiveUser.groupName;
        }


    }    
}
