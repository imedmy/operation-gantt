//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TestProject1
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//        }
//    }
//}


using ProjectRevision5.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System.Transactions;
using System.Linq;
using ProjectRevision5.Models;

namespace TestProject1
{
    /// <summary>
    ///This is a test class for TaskControllerTest and is intended
    ///to contain all TaskControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TaskControllerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion




        [TestMethod()]
        public void CreateTest()
        {
            TaskController taskcontroller = new TaskController();
            Task task = new Task();
            task.Row_ID = 20;
            task.Task_Name = "Testing Task";
            task.Start_Time = DateTime.Parse("11/12/2012");
            task.End_Time = DateTime.Parse("14/12/2012");

            ActionResult actual;
            actual = taskcontroller.Create(task);
            Assert.IsTrue(task.Row_ID != 0);

            ProjectEntities1 taskDB = new ProjectEntities1();
            var newTask = taskDB.Tasks.SingleOrDefault(a => a.Row_ID == task.Row_ID);
            Assert.AreEqual(task.Task_Name, newTask.Task_Name);
            Assert.AreEqual(task.Start_Time, newTask.Start_Time);
            Assert.AreEqual(task.End_Time, newTask.End_Time);
        }

        // Must run CreateTest before DeleteTest
        [TestMethod()]
        public void DeleteTest()
        {
            ProjectEntities1 taskDB = new ProjectEntities1();
            TaskController taskcontroller = new TaskController();
            ActionResult actual;
            ActionResult actual2;
            int id = 20;
            var newTask = taskDB.Tasks.Single(a => a.Row_ID == id);
            Assert.IsNotNull(newTask);
            actual = taskcontroller.Delete(id);
            actual2 = taskcontroller.DeleteConfirmed(id);
            var newTask2 = taskDB.Tasks.SingleOrDefault(a => a.Row_ID == id);
            Assert.IsNull(newTask2);
        }

        // Must run CreateTest before EditTest
        [TestMethod()]
        public void EditTest()
        {
            ProjectEntities1 taskDB = new ProjectEntities1();
            TaskController taskcontroller = new TaskController();
            ActionResult actual;
            int id = 20;
            actual = taskcontroller.Edit(id);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }
    }
}

