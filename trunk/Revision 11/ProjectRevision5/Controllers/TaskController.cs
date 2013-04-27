using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectRevision5.Models;

namespace ProjectRevision5.Controllers
{ 
    public class TaskController : Controller
    {
        private ProjectEntities db = new ProjectEntities();

        //
        // GET: /Task/

        public ViewResult Index()
        {
            ProjectEntities pen4 = new ProjectEntities();
            var ListQry = pen4.Tasks.Where(Task => Task.Predecessor != 0);
            foreach (var taskdetails in ListQry)
            {
                DatabaseManager.AssignPredecessor(taskdetails.Predecessor, taskdetails.Row_ID);
            }

            DatabaseManager.AssignSummaryDates();
            var TaskList = new List<Task>();
            TaskList = DatabaseManager.GetTasksToIndex;
            TaskList.Reverse();
            return View(TaskList);
        }

        //
        // GET: /Task/Details/5

        public ViewResult Details(int id)
        {
            Task task = db.Tasks.Single(t => t.Row_ID == id);
            return View(task);
        }

        //
        // GET: /Task/Create            // AssignPredecessor(int PreTaskId, int PostTaskId)

        public ActionResult Create()
        {
            int rownum = DatabaseManager.RowNoRetrieval;
            ViewBag.RowIDNumber = rownum + 1;
            ViewBag.Indent_Counter = 1;
            return View();
        } 

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.Predecessor < task.Row_ID)
                {
                    db.Tasks.AddObject(task);
                    db.SaveChanges();
                    if (task.Predecessor != 0)
                    {
                        DatabaseManager.AssignPredecessor(task.Predecessor, task.Row_ID);
                    }
                    DatabaseManager.AssignSummaryDates();
                    return RedirectToAction("Index");  
                }
                else
                {
                    return RedirectToAction("CreateBlocked");
                }
            }
            return View(task);
        }
        
        //
        // GET: /Task/Edit/5
 
        public ActionResult Edit(int id)
        {
            Task task = db.Tasks.Single(t => t.Row_ID == id);
            return View(task);
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.Predecessor < task.Row_ID)
                {
                    db.Tasks.Attach(task);
                    db.ObjectStateManager.ChangeObjectState(task, EntityState.Modified);
                    db.SaveChanges();
                    if (task.Predecessor != 0)
                    {
                        DatabaseManager.AssignPredecessor(task.Predecessor, task.Row_ID);
                    }
                    DatabaseManager.AssignSummaryDates();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("CreateBlocked");
                }
            }
            return View(task);
        }

        //
        // GET: /Task/Delete/5
 
        public ActionResult Delete(int id)
        {
            int rownum = DatabaseManager.RowNoRetrieval;
            Task task = db.Tasks.Single(t => t.Row_ID == id);
            if (rownum == id)            // Allows deletion of final task
            {
                return View(task);
            }

            else
            {
                Task task2 = db.Tasks.Single(t => t.Row_ID == id + 1);
                if (task.Indent_Counter >= task2.Indent_Counter)
                {
                    return View(task);
                }
                return RedirectToAction("DeleteBlocked");
            }
        }

        //
        // POST: /Task/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Task task = db.Tasks.Single(t => t.Row_ID == id);
            db.Tasks.DeleteObject(task);
            db.SaveChanges();
            DatabaseManager.RowSortAfterDelete(id);
            DatabaseManager.AssignSummaryDates();
            return RedirectToAction("Index");
        }

        public ViewResult DeleteBlocked()
        {
            return View();
        }

        public ViewResult CreateBlocked()
        {
            return View();
        }

        //
        // GET: /Task/Insert/5

        public ActionResult Insert(int id)
        {
            Task task = db.Tasks.Single(t => t.Row_ID == id);
            ViewBag.RowIDNumber = id;
            ViewBag.IndentCount = task.Indent_Counter;
            return View();
        }

        //
        // POST: /Task/Insert

        [HttpPost]
        public ActionResult Insert(Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.Predecessor < task.Row_ID)
                {
                    DatabaseManager.RowSortPreInsert(task.Row_ID);
                    db.Tasks.AddObject(task);
                    db.SaveChanges();
                    if (task.Predecessor != 0)
                    {
                        DatabaseManager.AssignPredecessor(task.Predecessor, task.Row_ID);
                    }
                    DatabaseManager.AssignSummaryDates();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("CreateBlocked");
                }
            }
            return View(task);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult TabLeft(int id)
        {
            int rownum = DatabaseManager.RowNoRetrieval;
            Task task = db.Tasks.SingleOrDefault(t => t.Row_ID == id);
            if ((rownum == id) && (task.Indent_Counter > 1))
            {
                task.Indent_Counter -= 1;
                db.SaveChanges();
                DatabaseManager.AssignSummaryDates();
                return RedirectToAction("Index");
            }

            if ((rownum != id) && (task.Indent_Counter > 1))
            {
                Task posttask = db.Tasks.SingleOrDefault(t => t.Row_ID == id + 1);
                if (task.Indent_Counter > posttask.Indent_Counter)
                {
                    task.Indent_Counter -= 1;
                }
            }
            db.SaveChanges();
            DatabaseManager.AssignSummaryDates();
            return RedirectToAction("Index");
        }

        public ActionResult TabRight(int id)
        {
            int rownum = DatabaseManager.RowNoRetrieval;
            Task task = db.Tasks.SingleOrDefault(t => t.Row_ID == id); 
            Task pretask = db.Tasks.SingleOrDefault(t => t.Row_ID == id - 1);

            if ((rownum == id)
                && (task.Indent_Counter <= pretask.Indent_Counter))
            {
                task.Indent_Counter += 1;
                db.SaveChanges();
                DatabaseManager.AssignSummaryDates();
                return RedirectToAction("Index");
            }

            if (rownum != id)
            {
                Task posttask = db.Tasks.SingleOrDefault(t => t.Row_ID == id + 1);
                if ((task.Indent_Counter >= posttask.Indent_Counter)
                    && (task.Indent_Counter <= pretask.Indent_Counter))
                {
                    task.Indent_Counter += 1;
                }
            }
            db.SaveChanges();
            DatabaseManager.AssignSummaryDates();
            return RedirectToAction("Index");
        }
    }
}