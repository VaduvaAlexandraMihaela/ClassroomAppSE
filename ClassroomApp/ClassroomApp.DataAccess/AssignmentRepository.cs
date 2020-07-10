using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomApp.DataAccess
{
    public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(ClassroomAppDbContext dbContext) :base(dbContext)
        {

        }

        public Assignment GetAssignmentById(Guid assignmentId)
        {
            var oneAssignment = dbContext.Assignments.Where(p => p.Id == assignmentId).SingleOrDefault();
            return oneAssignment;
        }
    }
}
