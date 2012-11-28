using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProject10.Models;

namespace MiniProject10.Controllers
{ 
    public class CityDetailsController : Controller
    {
        private MiniProjectEntities db = new MiniProjectEntities();

        //
        // GET: /CityDetails/

        public ViewResult Index()
        {
            return View(db.CityLocations.ToList());
        }

        // GET: /CityDetails/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CityDetails/Create

        [HttpPost]
        public ActionResult Create(CityLocation citylocation)
        {
            if (ModelState.IsValid)
            {
                db.CityLocations.AddObject(citylocation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(citylocation);
        }
        
        //
        // GET: /CityDetails/Edit/5

        [HttpGet]
        public ActionResult Edit(string id1, string id2)
        {
            CityLocation citylocation = db.CityLocations.Single(c => c.Country == id1 && c.City == id2);
            return View(citylocation);
        }

        //
        // POST: /CityDetails/Edit/5

        [HttpPost]
        public ActionResult Edit(CityLocation citylocation)
        {
            if (ModelState.IsValid)
            {
                db.CityLocations.Attach(citylocation);
                db.ObjectStateManager.ChangeObjectState(citylocation, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citylocation);
        }

        //
        // GET: /CityDetails/Delete/5

        [HttpGet]
        public ActionResult Delete(string id1, string id2)
        {
            CityLocation citylocation = db.CityLocations.Single(c => c.Country == id1 && c.City == id2);
            return View(citylocation);
        }

        //
        // POST: /CityDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id1, string id2)
        {
            CityLocation citylocation = db.CityLocations.Single(c => c.Country == id1 && c.City == id2);
            db.CityLocations.DeleteObject(citylocation);
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