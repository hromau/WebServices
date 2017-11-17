using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    interface INewUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string AccountNumber { get; set; }
        string Email { get; set; }
        DateTime DOB { get; set; }
        string GroupName { get; set; }

        void SetModel(ModelActiveUser modelActiveUser);
    }
}
