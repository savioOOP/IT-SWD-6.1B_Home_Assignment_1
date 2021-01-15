using Common;
using DataAcces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class TeacherService
    {
        private TeacherRepository _teacherRepo;

        public TeacherService()
        {
            _teacherRepo = new TeacherRepository();
        }

        //Adding a Teacher
        public void Add(Teacher t)
        {
            _teacherRepo.Add(t);
        }

        //Checking if the username exists
        public bool usernameExists(string username)
        {
            return _teacherRepo.GetTeachers().Any(x => x.Username == username);
        }

        //Checking if the password exists in the database and matches with the username
        public Teacher passwordMatch(Teacher teacher)
        {
            return _teacherRepo.GetTeachers().SingleOrDefault(x => x.Username == teacher.Username && x.Password == teacher.Password);
        }

        //Fetching the teachers ID
        public Teacher GetTeacher(string username)
        {
            return _teacherRepo.GetTeacher(username);
        }

        //List of Teachers
        public List<Teacher> GetTeachers() 
        {
            return _teacherRepo.GetTeachers().ToList();
        }
    }
}
