using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Display.Data
{
    /// <summary>
    /// The main <c>Course</c> class.
    /// Contains all properties matching the names of the database tables for program course lists.
    public class Course
    {
        /// <value>Gets the name of the course </value>
        public string CourseName { get; set; }
        /// <value>Gets the prerequisites as a string</value>

        public string Prereqs { get; set; }
        /// <value>Gets the amount of credit hours for the course </value>

        public int CreditHours { get; set; }
    }
}
