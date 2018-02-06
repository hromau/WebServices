using System;
using System.Collections.Generic;

namespace WebServices
{
    public partial class TimeTables
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string LessonTeacher { get; set; }
        public string Room { get; set; }
        public int Week { get; set; }
        public string Group { get; set; }
    }
}
