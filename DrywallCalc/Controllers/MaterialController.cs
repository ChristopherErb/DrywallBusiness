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
    public class MaterialController : Controller
    {
        // GET: Material
        [Authorize]
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaterialService(userId);
            var model = service.GetMaterials();
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MaterialCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var service = CreateMaterialService();

            if (service.CreateMaterial(model))
            {
                TempData["SaveResult"] = "Your material has been saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Material Could not be created.");
            return View(model);
        }



        public ActionResult Details(int id)
        {
            var svc = CreateMaterialService();
            var model = svc.GetMaterialById(id);
            return View(model);
        }


        public bool UpdateMaterial(MaterialEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Materials
                        .Single(e => e.ManagerId == model.ManagerId);

                entity.JobTitle = model.JobTitle;
                entity.LightBlueMud = model.LightBlueMud;
                entity.AllBlackMud = model.AllBlackMud;
                entity.EightBoard = model.EightBoard;
                entity.TenBoard = model.TenBoard;
                entity.TwelveBoard = model.TwelveBoard;

                    entity.Screws = model.Screws;

                return ctx.SaveChanges() == 1;
            }
        }



        private MaterialService CreateMaterialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaterialService(userId);
            return service;
        }
    }
}