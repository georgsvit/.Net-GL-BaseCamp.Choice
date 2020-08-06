using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChoiceA.Models;
using Microsoft.AspNetCore.Authorization;
using ChoiceA.Data;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ChoiceA.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Student student = _context.Students.FirstOrDefault(s => s.Name == User.Identity.Name);

            //if (student == null)
            //{
            //    return View();
            //}
            //return RedirectToAction("ChangeDisciplines", "Students", new { id = student.Id });

            Claim claim = User.Claims.FirstOrDefault(c => c.Type == "studentId");
            if (claim == null)
            {
                return View();
            }
            return RedirectToAction("ChangeDisciplines", "Students", new { id = Convert.ToInt32(claim.Value) });
        }

        public IActionResult Privacy()
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
