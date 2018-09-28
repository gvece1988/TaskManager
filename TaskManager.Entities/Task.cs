using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsTaskEnded { get; set; }

        public Task ParentTask { get; set; }
    }
}
