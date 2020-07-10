using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Abstractions
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        Assignment GetAssignmentById(Guid id); 
    }
}
