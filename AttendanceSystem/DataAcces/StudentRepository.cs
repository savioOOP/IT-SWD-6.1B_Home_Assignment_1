using Common;
using System.Linq;

namespace DataAcces
{
    public class StudentRepository: Connection
    {
        public StudentRepository() : base()
        {

        }

        //Adding Student and saving in into the DB
        public void Add(Student s)
        {
            AttendanceConnection.Students.Add(s);
            AttendanceConnection.SaveChanges();
        }

        //List of all Students
        public IQueryable<Student> GetStudents()
        {
            return AttendanceConnection.Students;
        }

        //Updating the Student Details
        public void Update(Student newDeatils)
        {
            AttendanceConnection.SaveChanges();
        }

        //Getting the Student Table by Student ID
        public Student GetStudent(int studentID)
        {
            return AttendanceConnection.Students.SingleOrDefault(x => x.StudentID == studentID);
        }

        //Getting the List of students that have the groupID
        public IQueryable<Student> GetStudents(int groupID)
        {
            return AttendanceConnection.Students.Where(x => x.GroupID == groupID);
        }
    }
}
