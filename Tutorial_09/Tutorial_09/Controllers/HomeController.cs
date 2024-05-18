﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tutorial_09.Models;

namespace Tutorial_09.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin, Client")]

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        
        public IActionResult OnlyAdmins()
        {
        return View();
        }

        [Authorize(Roles = "Client")]
    
        public IActionResult OnlyClients()
        {
        return View();
        }

        [Authorize(Roles = "Admin, Client")]
     
        public IActionResult OnlyClientsAndAdmins()
        {
        return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}