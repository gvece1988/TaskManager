using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BLL;
using TaskManager.Entities;

namespace TaskManager.API.Controllers
{
    public class TaskController : ApiController
    {
        private readonly TaskBL taskBL = new TaskBL();

        [HttpGet]
        public IHttpActionResult GetTasks()
        {
            return Ok(taskBL.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetTaskLookups()
        {
            return Ok(taskBL.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetTaskById(int taskId)
        {
            return Ok(taskBL.GetById(taskId));
        }

        public IHttpActionResult CreateTask(Task task)
        {
            taskBL.Add(task);

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult UpdateTask(Task task)
        {
            taskBL.Update(task);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
