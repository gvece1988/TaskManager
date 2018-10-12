using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Column("Task")]
        [Required]
        public string Title { get; set; }

        public int Priority { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool Done { get; set; }

        public int? ParentTaskId { get; set; }


        public Task ParentTask { get; set; }
    }
}
