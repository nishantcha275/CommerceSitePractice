using BusinessLayer.Services;
using CommerceSitePractice.Models;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CommerceSitePractice.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly ILoginServices _loginServices;
        public HomeController(ILoginServices loginServices)
        {
            _loginServices=loginServices;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginClass loginClass)
        {
            var user = await _loginServices.AuthenticateLoginAsync(loginClass.Username , loginClass.Password); 
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(user);
            }
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
