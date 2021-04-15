using DrywallCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrywallCalc.Controllers
{
    public class JobController : Controller
    {
        // GET: Jobs
        [Authorize]
        public ActionResult Index()
        {
            var model = new JobListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}