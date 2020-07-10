
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Abstractions
{
   public interface IGroupRepository : IRepository<Group>
    {
        Group GetGroupById(Guid groupId);
        Group GetGroupByName(string groupName);
    }
}
