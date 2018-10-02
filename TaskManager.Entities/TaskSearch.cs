using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class TaskSearch
    {
        public string Title { get; set; }

        public int? PriorityFrom { get; set; }

        public int? PriorityTo { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? ParentTaskId { get; set; }
    }
}
