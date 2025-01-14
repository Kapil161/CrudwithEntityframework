﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWITHEntityFramework.Controllers;
using CRUDWITHEntityFramework.Models;

namespace CRUDWITHEntityFramework.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Employee> emps = dbContext.Employees.ToList();
            return View(emps);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
       
       public IActionResult Delete(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.ID == id);
            if(emp!=null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.ID == id);
            return View();
        }
        [HttpPost]
        public IActionResult Edit (Employee emp)
        {
            dbContext.Employees.Update(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
