using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManager.BLL;
using TaskManager.Entities;

namespace TaskManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        private readonly TaskBL taskBL = new TaskBL();

        // GET: api/Task
        public IEnumerable<Task> Get()
        {
            return taskBL.GetAll();
        }

        // GET: api/Task/GetTaskLookups
        [Route("api/Task/GetTaskLookups")]
        public IEnumerable<Lookup> GetTaskLookups()
        {
            return taskBL.GetTaskLookups();
        }

        // GET: api/Task/5
        public IHttpActionResult Get(int id)
        {
            var task = taskBL.GetById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST: api/Task
        public void Post([FromBody]Task task)
        {
            taskBL.Add(task);
        }

        // PUT: api/Task
        public void Put([FromBody]Task task)
        {
            taskBL.Update(task);
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
            taskBL.End(id);
        }
    }
}
