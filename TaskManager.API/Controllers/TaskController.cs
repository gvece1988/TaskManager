using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManager.BLL;
using TaskManager.Entities;
using Microsoft.Practices.Unity;

namespace TaskManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        private readonly ITaskBL _taskBL;

        public TaskController(ITaskBL taskBL)
        {
            _taskBL = taskBL;
        }

        // GET: api/Task
        public IEnumerable<Task> Get()
        {
            return _taskBL.GetAll();
        }

        // GET: api/Task/GetTaskLookups
        [Route("api/Task/GetTaskLookups")]
        public IEnumerable<Lookup> GetTaskLookups()
        {
            return _taskBL.GetTaskLookups();
        }

        // GET: api/Task/5
        public IHttpActionResult Get(int id)
        {
            var task = _taskBL.GetById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST: api/Task
        public IHttpActionResult Post([FromBody]Task task)
        {
            if (ModelState.IsValid)
            {
                _taskBL.Add(task);
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Task
        public IHttpActionResult Put([FromBody]Task task)
        {
            if (ModelState.IsValid)
            {
                _taskBL.Update(task);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/Task/5
        public IHttpActionResult Delete(int id)
        {
            if (id > 0)
            {
                _taskBL.End(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
