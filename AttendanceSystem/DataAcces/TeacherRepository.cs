using Common;
using System.Linq;

namespace DataAcces
{
    public class TeacherRepository: Connection
    {
        public TeacherRepository() : base()
        {

        }

        //Adding Teacher and saving it into the DB
        public void Add(Teacher t)
        {
            AttendanceConnection.Teachers.Add(t);
            AttendanceConnection.SaveChanges();
        }

        //List Of All Teachers
        public IQueryable<Teacher> GetTeachers()
        {
            return AttendanceConnection.Teachers;
        }

        //Fetching the teachers ID
        public Teacher GetTeacher(string username)
        {
            return AttendanceConnection.Teachers.SingleOrDefault(x => x.Username == username);
        }   
    }
}
