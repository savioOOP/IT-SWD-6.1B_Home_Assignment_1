using Common;
using DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class GroupService
    {
        private GroupRepository _groupRepo;

        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }

        //Adding a Group
        public void Add(Group g)
        {
            _groupRepo.Add(g);
        }

        //Checking if the Group ID exists
        public bool groupIDExists(int groupID)
        {
            return _groupRepo.GetGroups().Any(x => x.GroupID == groupID);
        }

        //List Of All Groups
        public List<Group> GetGroups()
        {
            return _groupRepo.GetGroups().ToList();
        }
    }
}
