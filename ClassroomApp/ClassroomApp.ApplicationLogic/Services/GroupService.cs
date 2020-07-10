using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Services
{
   public class GroupService
    {
        IGroupRepository groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public Group GetGroupById(Guid groupId)
        {
            if (groupId == null)

            {

                throw new Exception("Null project id");

            }

            return groupRepository.GetGroupById(groupId);
        }

        public Group GetGroupByName(string groupName)
        {
            if(groupName == null)
            {
                throw new Exception("Null group name");
            }

            return groupRepository.GetGroupByName(groupName);
        }
    }
}
