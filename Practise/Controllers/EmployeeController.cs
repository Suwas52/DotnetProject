using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practise.Models;

namespace Practise.Controllers
{
    public class EmployeeController : Controller
    {

        mainEntities1 db;
        private object data;

        public EmployeeController()
        {
             db = new mainEntities1();
        }
        // GET: Employee0
        public ActionResult Index()
        {
            List<Employee> data = db.Employees.ToList();
            return View(data);
        }
        public ActionResult create()
        {
           
            return View(data);
        }
        
        public ActionResult Savadata(Employee Emp)
        {
            db.Employees.Add(Emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Employee data = db.Employees.Find(ID);
            return View(data);
        }
        public ActionResult UpdateData(Employee Emp)
        {
            db.Entry(Emp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            ;
        }


    }
} 