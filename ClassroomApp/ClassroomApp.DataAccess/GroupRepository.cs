using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomApp.DataAccess
{
   public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(ClassroomAppDbContext dbContext) : base(dbContext)
        {

        }

        public Group GetGroupById(Guid groupId)
        {
            var oneGroup = dbContext.Groups.Where(p => p.Id == groupId).SingleOrDefault();
            return oneGroup;
        }
    }
}
