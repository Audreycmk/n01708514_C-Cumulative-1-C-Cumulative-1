namespace Cumulative1.Models
{
    public class Teacher
    {
        //Represents Teacher

        //Teacher's Id
        public int TeacherId { get; set; }
        //Frst name of the Teacher
        public string? TeacherFName { get; set; }
        //Last name of the Teacher
        public string? TeacherLName { get; set;}
        // The employee number of the Teacher
        public string? EmployeeNumber { get;set; }
        // The hiring date of the Teacher
        public DateTime hiredate { get; set; }
        //Teacher's salary
        public double salary { get; set; }    
    }
}