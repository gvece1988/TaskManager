using System.Collections.Generic;
using TaskManager.Entities;

namespace TaskManager.BLL
{
    public interface ITaskBL
    {
        int Add(Task item);
        void End(int id);
        IEnumerable<Task> GetAll();
        Task GetById(int Id);
        IEnumerable<Lookup> GetTaskLookups();
        void Update(Task item);
    }
}