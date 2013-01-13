﻿using System;
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
            return View(db.Tasks.ToList());
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
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //
        // GET: /Task/Delete/5
 
        public ActionResult Delete(int id)
        {
            Task task = db.Tasks.Single(t => t.Row_ID == id);
            return View(task);
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
            return RedirectToAction("Index");
        }

        //
        // GET: /Task/Insert/5

        public ActionResult Insert(int id)
        {
            ViewBag.RowIDNumber = id;
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
                return RedirectToAction("Index");
            }
            return View(task);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}