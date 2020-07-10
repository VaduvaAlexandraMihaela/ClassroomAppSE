using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApp.Models.GroupModel
{
    public class GetAllGroupsViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
    }
}
