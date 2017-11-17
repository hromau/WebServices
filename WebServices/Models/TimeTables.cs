using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    public class TimeTables
    {
        public string LessonName { get; set; }
        public int LessonNumber { get; set; }
        public string LessonTeacher { get; set; }
        public string Room { get; set; }
        public string Week { get; set; }
    }
}
