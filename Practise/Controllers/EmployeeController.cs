﻿using System;
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
        employeeEntities db;
        private object data;

        public EmployeeController()
        {
             db = new employeeEntities();
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

        public ActionResult Edit(int id)
        {
            Employee data = db.Employees.Find(id);
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