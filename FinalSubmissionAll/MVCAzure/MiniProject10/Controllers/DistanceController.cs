using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProject10.Models;
using MiniProject10.Models;
using System.Data.Objects;
using System.Text;
using Geo1;

namespace MiniProject10.Controllers
{
    public class DistanceController : Controller
    {
        //MiniProjectEntities dbmp = new MiniProjectEntities();

        [HttpGet]
        public ActionResult Insert1()
        {
            ViewBag.FirstCountry = new SelectList(CitySelection.Countries);
            return View();
        }

        [HttpPost]               // result of form POST
        public ActionResult Insert1(string FirstCountry)
        {
            return RedirectToAction("Insert2",new {data = FirstCountry});
        }

        [HttpGet]
        public ActionResult Insert2(string data)
        {
            ViewBag.FirstCountry = data;
            ViewBag.FirstCity = new SelectList(CitySelection.Cities2(data));
            return View();
        }

        [HttpPost]               // result of form POST
        public ActionResult Insert2(string FirstCountry, string FirstCity)
        {
            return RedirectToAction("Insert3", new { country1 = FirstCountry, city1 = FirstCity });
        }

        [HttpGet]
        public ActionResult Insert3(string country1, string city1)
        {
            ViewBag.FirstCountry = country1;
            ViewBag.FirstCity = city1;
            ViewBag.SecondCountry = new SelectList(CitySelection.Countries);
            return View();
        }

        [HttpPost]               // result of form POST
        public ActionResult Insert3(string FirstCountry, string FirstCity, string SecondCountry)
        {
            return RedirectToAction("Insert4", new { country1 = FirstCountry, city1 = FirstCity, country2 = SecondCountry });
        }

        [HttpGet]
        public ActionResult Insert4(string country1, string city1, string country2)
        {
            ViewBag.FirstCountry = country1;
            ViewBag.FirstCity = city1;
            ViewBag.SecondCountry = country2;
            ViewBag.SecondCity = new SelectList(CitySelection.Cities2(country2));
            return View();
        }

        [HttpPost]               // result of form POST
        public ActionResult Insert4(string FirstCountry, string FirstCity, string SecondCountry, string SecondCity)
        {
            return RedirectToAction("Calculate", new { country1 = FirstCountry, city1 = FirstCity, 
                country2 = SecondCountry, city2 = SecondCity });
        }

        [HttpGet]
        public ActionResult Calculate(string country1, string city1, string country2, string city2)
        {
            double result = CitySelection.CalculateDist(country1, city1, country2, city2);
            ViewBag.Details = "Distance between " + city1 + " and " + city2;
            ViewBag.Result = "= " + result + " miles.";
            return View();
        }
    }
}
