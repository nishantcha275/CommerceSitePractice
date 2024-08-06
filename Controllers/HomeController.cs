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
            _loginServices = loginServices;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginClass loginClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _loginServices.AuthenticateLoginAsync(loginClass);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Unauthorized(ModelState);
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginClass loginClass)
        {
            if (!ModelState.IsValid)
            {
                return View(loginClass);
            }

            try
            {
                var result = await _loginServices.RegisterAsync(loginClass);

                if (result.Success)
                {
                    return RedirectToAction("Login", "Home");
                }
                ModelState.AddModelError("", result.ErrorMessage);
                return View(loginClass);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                return View(loginClass);
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
