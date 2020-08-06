using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Course_Display.Data
{    /// <summary>
     /// The <c>ReqCourse</c> class.
     /// Contains all properties matching the names of the database tables for required courses.
    public class ReqCourse
    {
        /// <value>Gets the name of the course </value>
        public string CourseName { get; set; }
    }
}
