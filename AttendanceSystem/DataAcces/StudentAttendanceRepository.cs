using Common;
using System;
using System.Linq;

namespace DataAcces
{
    public class StudentAttendanceRepository: Connection
    {
        public StudentAttendanceRepository() : base()
        {

        }

        public IQueryable<StudentAttendance> GetStudentAttendancesById(int studentID)
        {
            return AttendanceConnection.StudentAttendances.Where(x => x.StudentID == studentID);
        }

        public IQueryable<StudentAttendance> GetStudentAttendances(DateTime date, int teacherID)
        {
            return AttendanceConnection.StudentAttendances.Where(x => x.Lesson.DateTime == date.Date && x.Lesson.TeacherID == teacherID);
        }

        //Adding the Student Attendance and saving it into the DB
        public void Add(StudentAttendance sa)
        {
            AttendanceConnection.StudentAttendances.Add(sa);
            AttendanceConnection.SaveChanges();
        }
    }
}
