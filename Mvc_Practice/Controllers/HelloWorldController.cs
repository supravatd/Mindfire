using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Practice.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        //[Route("Home/test1")]
        public ActionResult Index()
        {
            return View();
        }
        //[Route("Home/test1")]
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}