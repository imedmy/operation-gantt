﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectRevision5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Operation Gantt!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
