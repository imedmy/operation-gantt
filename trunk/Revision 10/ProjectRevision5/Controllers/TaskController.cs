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
        // GET: /Task/Create

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
                db.Tasks.AddObject(task);
                db.SaveChanges();
                DatabaseManager.AssignSummaryDates();
                return RedirectToAction("Index");  
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
                db.Tasks.Attach(task);
                db.ObjectStateManager.ChangeObjectState(task, EntityState.Modified);
                db.SaveChanges();
                DatabaseManager.AssignSummaryDates();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //
        // GET: /Task/Delete/5
 
        public ActionResult Delete(int id)
        {
            int rownum = DatabaseManager.RowNoRetrieval;
            Task task = db.Tasks.Single(t => t.Row_ID == id);
            Task task2 = db.Tasks.Single(t => t.Row_ID == id + 1);
            if ((rownum == id) || (task.Indent_Counter >= task2.Indent_Counter))            // 1st Rule allows deletion of final task
            {
                return View(task);
            }

            else
            {
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
                DatabaseManager.RowSortPreInsert(task.Row_ID);
                db.Tasks.AddObject(task);
                db.SaveChanges();
                DatabaseManager.AssignSummaryDates();
                return RedirectToAction("Index");
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
            Task task = db.Tasks.SingleOrDefault(t => t.Row_ID == id);
            Task posttask = db.Tasks.SingleOrDefault(t => t.Row_ID == id + 1);
            if (task.Indent_Counter > posttask.Indent_Counter)
            {
                task.Indent_Counter -= 1;
            }
            db.SaveChanges();
            DatabaseManager.AssignSummaryDates();
            return RedirectToAction("Index");
        }

        public ActionResult TabRight(int id)
        {
            Task task = db.Tasks.SingleOrDefault(t => t.Row_ID == id); 
            Task pretask = db.Tasks.SingleOrDefault(t => t.Row_ID == id - 1);
            Task posttask = db.Tasks.SingleOrDefault(t => t.Row_ID == id + 1);
            if ((task.Indent_Counter >= posttask.Indent_Counter)
                && (task.Indent_Counter <= pretask.Indent_Counter))
            {
                task.Indent_Counter += 1;
            }
            db.SaveChanges();
            DatabaseManager.AssignSummaryDates();
            return RedirectToAction("Index");
        }
    }
}