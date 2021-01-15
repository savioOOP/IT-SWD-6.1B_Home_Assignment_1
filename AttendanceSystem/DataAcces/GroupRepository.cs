using Common;
using System.Linq;

namespace DataAcces
{
    public class GroupRepository: Connection
    {
        public GroupRepository() : base()
        {

        }

        //Adding a Group and saving it into the DB
        public void Add(Group g)
        {
            AttendanceConnection.Groups.Add(g);
            AttendanceConnection.SaveChanges();
        }

        //List of All Groups
        public IQueryable<Group> GetGroups()
        {
            return AttendanceConnection.Groups;
        }
    }
}
