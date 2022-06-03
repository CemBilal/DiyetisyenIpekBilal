using DiyetisyenIpekBilal.Data;
using DiyetisyenIpekBilal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiyetisyenIpekBilal.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly DytIpekBilalDBContext _context;

        public HomeController(DytIpekBilalDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutMee()
        {
            return View();
        }

        public IActionResult Achievements()
        {
            return View();
        }

        public IActionResult Recipes()
        {
            return View();
        }

        public IActionResult Comments()
        {
            return View();
        }

        public IActionResult Contact()
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