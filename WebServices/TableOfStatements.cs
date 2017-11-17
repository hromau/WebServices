using System;
using System.Collections.Generic;

namespace WebServices
{
    public partial class TableOfStatements
    {
        public string AccountNumber { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string TypeOfStatement { get; set; }
        public bool Verification { get; set; }
    }
}
