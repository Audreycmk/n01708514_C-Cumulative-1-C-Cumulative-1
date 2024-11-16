using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Cumulative1.Models;

namespace Cumulative1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }
    


        [HttpGet]
        [Route(template: "TeacherList")]
        /// <summary>
        /// Returns all Teacher records from the system.
        /// </summary>
        /// <example>
        /// GET api/Teacher/Listteacher -> {"teacherId": 1,"teacherFName": "Alexander","teacherLName": "Bennett","employeeNumber": "T378","hiredate": "2016-08-05T00:00:00","salary": 55.3}
        /// </example>
        /// <returns>
        /// A list of Teacher objects 
        /// </returns>
        public List<Teacher> ListTeachers()
        {
            List<Teacher> Teachers = new List<Teacher>();
         
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                MySqlCommand Command = Connection.CreateCommand();
                
                Command.CommandText = "select * from teachers";
        
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        string TeacherFName = ResultSet["teacherfname"].ToString();
                        string TeacherLName = ResultSet["teacherlname"].ToString();
                        string EmployeeNumber = ResultSet["employeenumber"].ToString();
                        DateTime hiredate = Convert.ToDateTime(ResultSet["hiredate"]);
                        double salary = Convert.ToDouble(ResultSet["salary"]);

                        Teacher CurrentTeacher = new Teacher()
                        {
                            TeacherId = TeacherId,
                            TeacherFName = TeacherFName,
                            TeacherLName = TeacherLName,
                            EmployeeNumber = EmployeeNumber,
                            hiredate = hiredate,
                            salary = salary
                        };

                        Teachers.Add(CurrentTeacher);

                    }
                }
            }
            return Teachers;
        }
        

        [HttpGet]
        [Route(template: "FindTeacher/{id}")]
        /// <summary>
        /// Returns Teacher by the Teacher’s ID
        /// </summary>
        /// <example>
        /// GET api/Teacher/FindTeacher/3 -> {"teacherId": 3,"teacherFName": "Linda","teacherLName": "Chan","employeeNumber": "T382","hiredate": "2015-08-22T00:00:00","salary":60.22}
        /// </example>
        /// <returns>
        /// A Teacher object matching the specified ID, or an empty object if no matching record is found.
        /// </returns>

        public Teacher FindTeacher(int id)
        {

            Teacher SelectedTeacher = new Teacher();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
         
                MySqlCommand Command = Connection.CreateCommand();
             
                Command.CommandText = "select * from teachers where teacherid=@id";
                Command.Parameters.AddWithValue("@id", id);
           
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        string TeacherFName = ResultSet["teacherfname"].ToString();
                        string TeacherLName = ResultSet["teacherlname"].ToString();
                        string EmployeeNumber = ResultSet["employeenumber"].ToString();
                        DateTime hiredate = Convert.ToDateTime(ResultSet["hiredate"]);
                        double salary = Convert.ToDouble(ResultSet["salary"]);
       
                            SelectedTeacher.TeacherId = TeacherId;
                            SelectedTeacher.TeacherFName = TeacherFName;
                            SelectedTeacher.TeacherLName = TeacherLName;
                            SelectedTeacher.EmployeeNumber = EmployeeNumber;
                            SelectedTeacher.hiredate = hiredate;
                            SelectedTeacher.salary = salary;
                        
                    }
                }
            }
            return SelectedTeacher;
        }

    }
  }