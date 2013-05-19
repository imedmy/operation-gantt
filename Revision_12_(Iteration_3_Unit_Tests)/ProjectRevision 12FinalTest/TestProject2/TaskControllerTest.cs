using ProjectRevision5.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System.Linq;
using ProjectRevision5.Models;

namespace TestProject2
{
    [TestClass()]
    public class TaskControllerTest
    {
        [TestMethod()]
        public void CreateTest()
        {
            ProjectEntities taskDB = new ProjectEntities();
            TaskController taskcontroller = new TaskController();
            Task task = new Task();
            task.Row_ID = 19;
            task.Task_Name = "Testing Task";
            task.Start_Time = DateTime.Parse("11/12/2012");
            task.End_Time = DateTime.Parse("14/12/2012");
            task.Indent_Counter = 1;
            task.Predecessor = 0;

            ActionResult actual;
            actual = taskcontroller.Create(task);
            Assert.IsTrue(task.Row_ID != 0);

            var newTask = taskDB.Tasks.SingleOrDefault(a => a.Row_ID == task.Row_ID);
            Assert.AreEqual(task.Task_Name, newTask.Task_Name);
            Assert.AreEqual(task.Start_Time, newTask.Start_Time);
            Assert.AreEqual(task.End_Time, newTask.End_Time);
            Assert.AreEqual(task.Indent_Counter, newTask.Indent_Counter);
            Assert.AreEqual(task.Predecessor, newTask.Predecessor);
        }

        [TestMethod()]
        public void EditTest()
        {
            ProjectEntities taskDB = new ProjectEntities();
            TaskController taskcontroller = new TaskController();
            ActionResult actual;
            int id = 19;
            actual = taskcontroller.Edit(id);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ProjectEntities taskDB = new ProjectEntities();
            TaskController taskcontroller = new TaskController();
            ActionResult actual;
            ActionResult actual2;
            int id = 19;
            var newTask = taskDB.Tasks.Single(a => a.Row_ID == id);
            Assert.IsNotNull(newTask);
            actual = taskcontroller.Delete(id);
            actual2 = taskcontroller.DeleteConfirmed(id);
            var newTask2 = taskDB.Tasks.SingleOrDefault(a => a.Row_ID == id);
            Assert.IsNull(newTask2);
        }       
    }
}

