using Common;

namespace DataAcces
{
    public class LessonRepository: Connection
    {
        public LessonRepository() : base()
        {

        }

        //Adding Teacher and saving it into the DB
        public int Add(Lesson lesson)
        {
            AttendanceConnection.Lessons.Add(lesson);
            AttendanceConnection.SaveChanges();

            return lesson.LessonID;
        }
    }
}
