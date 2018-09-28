using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DAL;
using TaskManager.Entities;

namespace TaskManager.BLL
{
    public class TaskBL
    {
        private readonly TaskManagerContext context = new TaskManagerContext();

        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }

        public Task GetById(int Id)
        {
            return context.Tasks.FirstOrDefault(m => m.Id == Id);
        }

        public void Add(Task item)
        {
            context.Tasks.Add(item);
            context.SaveChanges();
        }

        public void Update(Task item)
        {
            var task = context.Tasks.FirstOrDefault(m => m.Id == item.Id);

            task.Name = item.Name;
            task.ParentTask = item.ParentTask;
            task.Priority = item.Priority;
            task.StartDate = item.StartDate;
            task.EndDate = item.EndDate;

            context.SaveChanges();
        }
    }
}
