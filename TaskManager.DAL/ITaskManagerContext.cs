using System.Data.Entity;
using TaskManager.Entities;

namespace TaskManager.DAL
{
    public interface ITaskManagerContext
    {
        DbSet<Task> Tasks { get; set; }

        int SaveChanges();
    }
}