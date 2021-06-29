using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Base;
using Web.Repository.Data;

namespace Web.Controllers
{
    [Authorize]
    public class PanelController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository userRepository;

        public PanelController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }
        public ActionResult Users()
        {
            return View();
        }

        public async Task<JsonResult> GetUsers()
        {
            var result = await userRepository.GetUsers();
            return Json(result);
        }

        // GET: PanelController
        public ActionResult Index()
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
