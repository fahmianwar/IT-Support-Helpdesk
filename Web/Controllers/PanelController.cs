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
    public class PanelController : Controller
    {
        UserRepository userRepository;

        public PanelController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult Users()
        {
            return View();
        }

        public async Task<JsonResult> GetUsers()
        {
            var result = await userRepository.GetUsers();
            return Json(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> Auth(LoginVM loginVM)
        //{
        //    var jwToken = userRepository.Auth(loginVM);
        //    if (jwToken == null)
        //    {
        //        return RedirectToAction("index");
        //    }
        //    HttpContext.Session.SetString("JWToken", jwToken.Token);
        //    return RedirectToAction("Index", "Panel");
        //}


        // GET: PanelController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateTicket()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
