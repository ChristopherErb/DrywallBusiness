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

        private MaterialService CreateMaterialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaterialService(userId);
            return service;
        }
    }
}