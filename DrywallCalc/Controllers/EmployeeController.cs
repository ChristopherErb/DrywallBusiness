using DrywallCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrywallCalc.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var model = new EmployeeListItem[0];
            return View(model);
        }



        //CreateMethod

        public ActionResult Create()
        {
            return View();
        }
    }
}