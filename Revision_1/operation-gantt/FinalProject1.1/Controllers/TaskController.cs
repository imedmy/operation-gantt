using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject1._1.Models;

namespace FinalProject1._1.Controllers
{ 
    public class TaskController : Controller
    {
        private ProjectEntities1 db = new ProjectEntities1();

        //
        // GET: /Task/

        public ActionResult Index()
        {
            using (var db = new ProjectEntities1())
            {
                return View(db.Tasks.ToList());
            }
        }

        //
        // GET: /Task/Details/5

        public ViewResult Details(string id)
        {
            Task task = db.Tasks.Find(id);
            return View(task);
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(task);
        }
        
        //
        // GET: /Task/Edit/5
 
        public ActionResult Edit(string id)
        {
            Task task = db.Tasks.Find(id);
            return View(task);
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //
        // GET: /Task/Delete/5
 
        public ActionResult Delete(string id)
        {
            Task task = db.Tasks.Find(id);
            return View(task);
        }

        //
        // POST: /Task/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}