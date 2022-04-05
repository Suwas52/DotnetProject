using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practise.Models;

namespace Practise.Controllers
{
    public class employeesalaryController : Controller
    {
        mainEntities1 db;
        private object data;

        public employeesalaryController()
        {
            db = new mainEntities1();
        }
        // GET: Employee0
        public ActionResult Index()
        {
            List<employee_salary_details> data = db.employee_salary_details.ToList();
            return View(data);
        }
        public ActionResult create()
        {
            var emplist = db.Employees.ToList();
            ViewBag.employeesalaryList = new SelectList(emplist, "ID", "Name");
            return View(data);
        }
        [HttpPost]
        public ActionResult Create(employee_salary_details employee_Salary_Details)
        {
            db.employee_salary_details.Add(employee_Salary_Details);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult Savadata(employee_salary_details Emp)
        {
            db.employee_salary_details.Add(Emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            employee_salary_details data = db.employee_salary_details.Find(id);
            return View(data);
        }
        public ActionResult UpdateData(employee_salary_details Emp)
        {
            db.Entry(Emp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            ;
        }


    }
}