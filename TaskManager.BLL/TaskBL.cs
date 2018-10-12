using System.Collections.Generic;
using System.Linq;
using TaskManager.DAL;
using TaskManager.Entities;

namespace TaskManager.BLL
{
    public class TaskBL : ITaskBL
    {
        private readonly ITaskManagerContext _context;

        public TaskBL(ITaskManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAll()
        {
            return _context.Tasks.OrderByDescending(m => m.Id).ToArray();
        }

        public IEnumerable<Lookup> GetTaskLookups()
        {
            return _context.Tasks.Select(m => new Lookup { Id = m.Id, Name = m.Title }).ToArray();
        }

        public Task GetById(int Id)
        {
            return _context.Tasks.FirstOrDefault(m => m.Id == Id);
        }

        public int Add(Task item)
        {
            _context.Tasks.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void Update(Task item)
        {
            var task = _context.Tasks.FirstOrDefault(m => m.Id == item.Id);

            task.Title = item.Title;
            task.ParentTask = item.ParentTask;
            task.Priority = item.Priority;
            task.StartDate = item.StartDate;
            task.EndDate = item.EndDate;
            task.ParentTaskId = item.ParentTaskId;

            _context.SaveChanges();
        }

        public void End(int id)
        {
            var task = _context.Tasks.FirstOrDefault(m => m.Id == id);
            task.Done = true;

            _context.SaveChanges();
        }
    }
}
