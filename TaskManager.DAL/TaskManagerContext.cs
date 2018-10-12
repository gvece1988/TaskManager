using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DAL
{
    public class TaskManagerContext : DbContext, ITaskManagerContext
    {
        public DbSet<Task> Tasks { get; set; }
    }
}
