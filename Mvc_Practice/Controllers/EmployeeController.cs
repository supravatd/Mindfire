using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Practice.Models;

namespace Mvc_Practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly PracticeEntities dbContext;

        public EmployeeController()
        {
            dbContext = new PracticeEntities();
        }

        // GET: Employee
        public ActionResult Read()
        {
            var employees = dbContext.Employees.ToList();
            return View(employees);
        }

        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(dbContext.Departments, "Department_ID", "Department_Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                return RedirectToAction("Read");
            }

            ViewBag.Departments = new SelectList(dbContext.Departments, "Department_ID", "Department_Name", employee.Department_ID);
            return View(employee);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departments = new SelectList(dbContext.Departments, "Department_ID", "Department_Name");

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(employee).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(dbContext.Departments, "Department_ID", "Department_Name");

            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}