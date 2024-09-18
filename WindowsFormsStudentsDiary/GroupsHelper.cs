using System.Collections.Generic;

namespace WindowsFormsStudentsDiary
{
    class GroupsHelper
    {
        public static List<Group> GetGroups(string defaultGroup)
        {
            return new List<Group>
            {
                new Group { Id = 0, Name = defaultGroup},
                new Group { Id = 1, Name = "1a"},
                new Group { Id = 2, Name = "1b" }
            };
        }
    }
}
