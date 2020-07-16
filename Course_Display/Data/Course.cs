using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Display.Data
{
    public class Course
    {
        public string CourseName { get; set; }

        public string Prereqs { get; set; }

        public int CreditHours { get; set; }
    }
}
