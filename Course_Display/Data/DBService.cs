using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Display.Data
{
    public class DBService
    {
        private readonly CoursedbContext _context;
        public DBService(CoursedbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Takes <paramref name="CourseName"> and grabs the information from the database and converts it into a Course object
        /// </summary>
        /// <param name="CourseName">A string.</param>
        public Task<Course> GetCourseAsync(string CourseName)
        {
            Course course = new Course();
            bool skip = false;

            string strConn = "Data Source = database-1.cinez0pdciee.us-east-2.rds.amazonaws.com,1433; Initial Catalog = CourseDB; User ID = admin; Password = **OrigamiTigerKing**;";

            SqlConnection conn = new SqlConnection(strConn);

            string[] CourseNameArray = CourseName.Split(" ");
            string[] NoSqlTableCourses = { "ISQA", "ITIN", "STAT" };

            string DBToCheck = CourseNameArray[0];

            foreach(string s in NoSqlTableCourses)
            {
                if(DBToCheck == s)
                {
                    skip = true;
                    break;
                }
            }

            if(skip == false)
            {
                string sql = "SELECT * FROM " + DBToCheck + "List WHERE CourseName='" + CourseName + "';";

                SqlCommand command = new SqlCommand(sql, conn);

                //opening connection and executing the query

                conn.Open();

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())

                {
                    course.CourseName = dr[0].ToString();

                    course.CreditHours = Int32.Parse(dr[1].ToString());

                    course.Prereqs = dr[2].ToString();
                }

                conn.Close();
            }
            else
            {
                course = null;
            }
            Task<Course> task = Task.FromResult(course);

            //return personModels;

            return task;

        }

    }
}
