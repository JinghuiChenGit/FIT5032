using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week3.HelloWorld;
using week3.Exercise;

namespace week3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            Hello hello = new Hello();
            ViewBag.Message = "Your application description page.";
            ViewBag.Message2 = hello.GetHello();
            ExampleDictionary exampleDictionary = new ExampleDictionary();
            exampleDictionary.Example();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}