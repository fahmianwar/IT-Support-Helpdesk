using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Base;
using Web.Repository.Data;

namespace Web.Controllers
{
    public class PanelController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository userRepository;
        public PanelController(UserRepository userRepository) : base(userRepository)
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

        public IActionResult Cases()
        {
            return View();
        }

        public IActionResult Convertations()
        {
            return View();
        }

        public IActionResult Attachments()
        {
            return View();
        }

        public IActionResult Histories()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult StatusCodes()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult CreateTicket()
        {
            return View();
        }

        //[AllowAnonymous]
        //[Route("ViewConvertationByCaseId")]
        //[HttpGet("ViewConvertationByCaseId/{caseId}")]
        public IActionResult ViewConvertationByCaseId(int caseId)
        {
            ViewBag.CaseId = caseId;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
