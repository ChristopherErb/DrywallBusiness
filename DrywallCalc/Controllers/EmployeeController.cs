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

    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            var userId = (User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            var model = service.GetEmployees();
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }


        //CreateMethod
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateEmployeeService();

           if(service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Employee has successfully been added";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Employee cannot be added");
            return View(model);
        }

        private EmployeeService CreateEmployeeService()
        {
            var userId = User.Identity.GetUserId();
            var service = new EmployeeService(userId);
            return service;
        }

        public ActionResult Edit(string id)
        {
            var service = CreateEmployeeService();
            var detail = service.GetEmployeeById(id);
            var model =
            new EmployeeEdit
            {
                FullName = detail.FullName,
                Title = detail.Title,
                PayRate = detail.PayRate
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, EmployeeEdit Model)
        {
            if(!ModelState.IsValid) return View(Model);

            if(Model.Employee_Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(Model);
            }

            var service = CreateEmployeeService();
            if (service.UpdateEmployee(Model))
            {
                TempData["Save Result"] = "Your change was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your change could not be updated");
            return View();
        }

        [ActionName("delete")]
        public ActionResult Delete(string userId)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(userId);
            return View(model);
        }



        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmployeeService();
            service.DeleteEmployee(id);
            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction("Index");
        }



        public ActionResult Details(string  userId)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(userId);
            return View(model);
        }
    }
    
}