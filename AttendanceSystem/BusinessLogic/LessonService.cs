using Common;
using DataAcces;

namespace BusinessLogic
{
    public class LessonService
    {
        private LessonRepository _lessonRepo;

        public LessonService()
        {
            _lessonRepo = new LessonRepository();
        }

        //Adding a Teacher
        public int Add(Lesson lesson)
        {
            return _lessonRepo.Add(lesson);
        }
    }
}
