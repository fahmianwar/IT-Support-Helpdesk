using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Repository.Data;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        //readonly HttpClient client = new HttpClient
        //{
        //    BaseAddress = new Uri("https://localhost:44381/api/")
        //};
        UserRepository repository;
        public LoginController(UserRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[Route("login")]
        //public IActionResult Login()
        //{
        //    if (HttpContext.Session.IsAvailable)
        //    {
        //        if (HttpContext.Session.GetString("Id") != null)
        //        {
        //            return Redirect("~/Views/Login/Index.cshtml");
        //        }
        //    }
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var jwToken = await repository.Auth(loginVM);
            if (jwToken == null)
            {
                return RedirectToAction("index");
            }
            HttpContext.Session.SetString("JWToken", jwToken.Token);
            return RedirectToAction("index", "home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }
    }
}
