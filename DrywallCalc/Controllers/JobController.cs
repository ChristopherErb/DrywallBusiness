using DrywallCalc.Models;
using DrywallCalc.Services;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            var model = service.GetJobs();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateJobService();

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "Your Job has been saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Job Could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }


        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.CurrentJobId == model.CurrentJobId);

                entity.Address = model.Address;
                entity.CurrentJobId = model.CurrentJobId;
                entity.Title = model.Title;
                entity.Owner = model.Owner;


                return ctx.SaveChanges() == 1;
            }
        }





        private JobService CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            return service;
        }
    }
}