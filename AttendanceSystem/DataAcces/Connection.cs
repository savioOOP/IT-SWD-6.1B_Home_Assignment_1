using Common;

namespace DataAcces
{
    public class Connection
    {
        public AttendanceSystemEntities AttendanceConnection { get; set; }

        public Connection()
        {
            AttendanceConnection = new AttendanceSystemEntities();
        }
    }
}
