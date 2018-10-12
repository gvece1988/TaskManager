using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManager.API.Controllers;
using TaskManager.BLL;
using TaskManager.Entities;
using System.Linq;
using System;
using System.Web.Http.Results;

namespace TaskManager.API.Tests
{
    [TestClass]
    public class TaskControllerTest
    {
        private readonly Mock<ITaskBL> taskBL;
        private readonly TaskController taskController;

        public TaskControllerTest()
        {
            taskBL = new Mock<ITaskBL>();
            taskController = new TaskController(taskBL.Object);
        }

        [TestMethod]
        public void GetAll()
        {
            taskBL.Setup(m => m.GetAll()).Returns(new[] { GetTestTask() });

            var tasks = taskController.Get();

            Assert.IsNotNull(tasks);
            Assert.IsTrue(tasks.Count() > 0);
        }

        [TestMethod]
        public void GetTaskLookups()
        {
            taskBL.Setup(m => m.GetTaskLookups()).Returns(new[] { new Lookup { Id = 1, Name = "Test task" } });
            var taskLookups = taskController.GetTaskLookups();

            Assert.IsNotNull(taskLookups);
            Assert.IsTrue(taskLookups.Count() > 0);
        }

        [TestMethod]
        public void Get()
        {
            taskBL.Setup(m => m.GetById(1)).Returns(GetTestTask());
            var result = taskController.Get(1) as OkNegotiatedContentResult<Task>;             
            
            Assert.IsNotNull(result.Content);
        }

        [TestMethod]
        public void Get_ErrorResponse()
        {
            taskBL.Setup(m => m.GetById(1)).Returns(GetTestTask());
            var result = taskController.Get(3) as NotFoundResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post()
        {
            var task = GetTestTask();

            taskBL.Setup(m => m.Add(task));

            var result = taskController.Post(task) as OkResult;

            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void Put()
        {
            var task = GetTestTask();

            taskBL.Setup(m => m.Update(task));

            var result = taskController.Put(task) as OkResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        { 
            taskBL.Setup(m => m.End(It.IsAny<int>()));

            var result = taskController.Delete(1) as OkResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_ErrorResponse()
        {
            taskBL.Setup(m => m.End(It.IsAny<int>()));

            var result = taskController.Delete(0) as BadRequestResult;

            Assert.IsNotNull(result);
        }

        private Task GetTestTask()
        {
            return new Task
            {
                Title = "Test task",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
        }
    }
}
