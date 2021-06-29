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

        UserRepository repository;
        public LoginController(UserRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM loginVM)
        {
            var jwToken = await repository.Auth(loginVM);
            if (jwToken == null)
            {
                return RedirectToAction("index");
            }
            HttpContext.Session.SetString("JWToken", jwToken.Token);
            return RedirectToAction("Index", "Panel");
        }

    }
}
