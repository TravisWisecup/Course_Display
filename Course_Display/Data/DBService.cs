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

        public async Task<Course> GetClassAsync(string CourseName)
        {
            var course = new Course();
            if (CourseName.StartsWith("CSCI"))
            {
                return _context.CSCIList.First(e => e.CourseName == CourseName);
            }
            else if (CourseName.StartsWith("CYBR"))
            {
                return _context.CYBRList.First(e => e.CourseName == CourseName);
            }
            else if (CourseName.StartsWith("CIST"))
            {
                return _context.CISTList.First(e => e.CourseName == CourseName);
            }
            else if (CourseName.StartsWith("MATH"))
            {
                return _context.MATHList.First(e => e.CourseName == CourseName);
            }

            if (course == null)
            {
                course.CourseName = "Missing from Database";
                course.CreditHours = 0;
                course.Prereqs = "";
            }

            return course;
        }

        public Task<Course> GetCourseAsync(string CourseName)

        {
            Course course = new Course();

            string strConn = "Data Source = database-1.cinez0pdciee.us-east-2.rds.amazonaws.com,1433; Initial Catalog = CourseDB; User ID = admin; Password = **OrigamiTigerKing**";

            SqlConnection conn = new SqlConnection(strConn);

            string DBToCheck = "";

            if (CourseName.StartsWith("CSCI"))
            {
                DBToCheck = "CSCIList";
            }
            else if (CourseName.StartsWith("CYBR"))
            {
                DBToCheck = "CYBRList";
            }
            else if (CourseName.StartsWith("CIST"))
            {
                DBToCheck = "CISTList";
            }
            else if (CourseName.StartsWith("MATH"))
            {
                DBToCheck = "MATHList";
            }

            string sql = "SELECT * FROM " + DBToCheck + " WHERE CourseName='" + CourseName + "';";

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

        public void Testing(string CourseName)
        {
            Course course = new Course();

            string strConn = "Data Source = database-1.cinez0pdciee.us-east-2.rds.amazonaws.com,1433; Initial Catalog = CourseDB; User ID = admin; Password = **OrigamiTigerKing**";

            SqlConnection conn = new SqlConnection(strConn);

            string DBToCheck = "";

            if (CourseName.StartsWith("CSCI"))
            {
                DBToCheck = "CSCIList";
            }
            else if (CourseName.StartsWith("CYBR"))
            {
                DBToCheck = "CYBRList";
            }
            else if (CourseName.StartsWith("CIST"))
            {
                DBToCheck = "CISTList";
            }
            else if (CourseName.StartsWith("MATH"))
            {
                DBToCheck = "MATHList";
            }

            string sql = "SELECT * FROM " + DBToCheck + " WHERE CourseName='" + CourseName + "';";

            SqlCommand command = new SqlCommand(sql, conn);

            //opening connection and executing the query

            conn.Open();
            conn.Close();
        }
    }
}
