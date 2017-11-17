using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    public class ModelNewUser : INewUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string GroupName { get; set; }

        public void SetModel(ModelActiveUser modelActiveUser)
        {
            throw new NotImplementedException();
        }
    }
}
