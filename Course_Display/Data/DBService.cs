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


        public Task<Course> GetCourseAsync(string CourseName)

        {
            Course course = new Course();

            string strConn = "Data Source = database-1.cinez0pdciee.us-east-2.rds.amazonaws.com,1433; Initial Catalog = CourseDB; User ID = admin; Password = **OrigamiTigerKing**;";

            SqlConnection conn = new SqlConnection(strConn);

            string[] CourseNameArray = CourseName.Split(" ");

            string DBToCheck = CourseNameArray[0];

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

            Task<Course> task = Task.FromResult(course);

            //return personModels;

            return task;

        }

    }
}
