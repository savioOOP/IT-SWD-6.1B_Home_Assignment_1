using Common;
using System;
using DataAcces;
using System.Linq;

namespace BusinessLogic
{
    public class StudentAttendanceService
    {

        private StudentAttendanceRepository _studentAttendanceRepo;

        public StudentAttendanceService()
        {
            _studentAttendanceRepo = new StudentAttendanceRepository();
        }

        //Adding the Student Attendance
        public void Add(StudentAttendance sa)
        {
            _studentAttendanceRepo.Add(sa);
        }

        //Getting the total number of attendances for students
        private int GetTotalNumOfAttendancesForStudent(int studentID)
        {
            return _studentAttendanceRepo.GetStudentAttendancesById(studentID).Count();
        }

        //Getting the total number of attendances for students when they are present
        private int GetTotalNumOfAttendancesForStudentWhenPresent(int studentID)
        {
            return _studentAttendanceRepo.GetStudentAttendancesById(studentID).Where(s => s.Pressence == true).Count();
        }

        //Getting the Avergae Percentage Of a Student's Attendance
        public int GetAttendancePercentage(int studentID)
        {
            double presentTotal = GetTotalNumOfAttendancesForStudentWhenPresent(studentID);
            double attendanceTotal = GetTotalNumOfAttendancesForStudent(studentID);

            //Incase if the student does not have an Attendance
            if(attendanceTotal == 0)
            {
                return 100; //return 100%
            }

            double result = presentTotal / attendanceTotal;
            return Convert.ToInt32(result * 100);
        }

        //Getting the Attendance for a particular day
        public int GetAttendancesForDay(DateTime date, int teacherID)
        {
            return _studentAttendanceRepo.GetStudentAttendances(date, teacherID).Count();
        }
    }
}