using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManager.DAL;
using TaskManager.Entities;

namespace TaskManager.BLL.Tests
{
    [TestClass]
    public class TaskBLTest
    {
        private Mock<ITaskManagerContext> context;
        private TaskBL taskBL;

        [TestInitialize]
        public void Setup()
        {
            context = new Mock<ITaskManagerContext>();
            taskBL = new TaskBL(context.Object);

            var mockSet = new Mock<DbSet<Task>>();
            var tasks = new List<Task> { GetTestTask() };
            var queryableList = tasks.AsQueryable();

            mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

            mockSet.Setup(m => m.Add(It.IsAny<Task>())).Callback((Task task) => tasks.Add(task));
            mockSet.Setup(m => m.Remove(It.IsAny<Task>())).Callback((Task task) => tasks.Remove(task));

            context.Setup(m => m.Tasks).Returns(mockSet.Object);
        }

        [TestMethod]
        public void GetAll()
        {
            var tasks = taskBL.GetAll();

            Assert.IsNotNull(tasks);
        }

        [TestMethod]
        public void GetTaskLookups()
        {
            var taskLookups = taskBL.GetTaskLookups();

            Assert.IsNotNull(taskLookups);
        }

        [TestMethod]
        public void GetById()
        {
            var task = taskBL.GetById(1);

            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void Add()
        {
            var actual = taskBL.Add(new Task
            {
                Id = 2,
                Title = "Test task2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            });

            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Update()
        {
            var newTitle = "Test task1";

            var task = GetTestTask();
            task.Title = newTitle;

            taskBL.Update(task);

            task = taskBL.GetById(1);

            Assert.IsTrue(task.Title == newTitle);
        }

        [TestMethod]
        public void End()
        {
            taskBL.End(1);

            var task = taskBL.GetById(1);

            Assert.IsTrue(task.Done);
        }

        private Task GetTestTask()
        {
            return new Task
            {
                Id = 1,
                Title = "Test task",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
        }
    }
}
