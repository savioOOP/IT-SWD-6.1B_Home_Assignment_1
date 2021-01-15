using Common;
using DataAcces;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class StudentService
    {
        private StudentRepository _studentRepo;

        public StudentService()
        {
            _studentRepo = new StudentRepository();
        }

        //Adding a Student
        public void Add(Student s)
        {
            _studentRepo.Add(s);  
        }

        //Checking if the Student ID exists 
        public bool studentIDExists(int studentID)
        {
            return _studentRepo.GetStudents().Any(x => x.StudentID == studentID);
        }

        //Updating the Student Details
        public void Update(int StudentID, string newName, string newSurname, string newEmail)
        {
            var studentUpdateDeatils = _studentRepo.GetStudent(StudentID);
            studentUpdateDeatils.Name = newName;
            studentUpdateDeatils.Surname = newSurname;
            studentUpdateDeatils.Email = newEmail;

            _studentRepo.Update(studentUpdateDeatils);
        }

        //Getting the List of students that have the groupID
        public IQueryable<Student> GetStudents(int groupID)
        {
            return _studentRepo.GetStudents(groupID);
        }
    }
}