using DiyetisyenIpekBilal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiyetisyenIpekBilal.Controllers
{
  

    
    public class AdminController : Controller
    {
        private readonly DytIpekBilalDBContext _context;

        public AdminController(DytIpekBilalDBContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

       



    }
}
