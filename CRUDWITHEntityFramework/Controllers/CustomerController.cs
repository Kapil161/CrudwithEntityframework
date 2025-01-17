﻿using CRUDWITHEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWITHEntityFramework.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Location> Locations = dbContext.Locations.ToList();
            return View(Locations);
        }
        public IActionResult CustomerList(int Id)
        {
            List<Customer> Customers = dbContext.Customers.Where(e=>e.Location.Id==Id).ToList();
            return View(Customers);
        }
    }
}
