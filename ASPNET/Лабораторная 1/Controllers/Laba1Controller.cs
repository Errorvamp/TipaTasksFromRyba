using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAspnet1.Controllers
{
    public class Laba1Controller : Controller
    {
        // GET: Laba1
        public ActionResult FirstViewMethod()
        {
            ViewBag.Vegetables = GetVegetablesList();
            return View();
        }
        public ActionResult SecondViewMethod()
        {
            return View(GetVegetablesList().OrderBy(x => x).ToList());
        }
        public ActionResult ThirdViewMethod()
        {
            return View(GetVegetablesList().OrderBy(x => x).ToList());
        }
        public List<string> GetVegetablesList()
        {
            List<string> vegetables = new List<string>();
            vegetables.Add("Томат");
            vegetables.Add("Огурец");
            vegetables.Add("Картофель");
            vegetables.Add("Кабачок");
            vegetables.Add("Баклажан");
            vegetables.Add("Капуста");
            vegetables.Add("Брокколи");

            return vegetables;
        }
    }
}