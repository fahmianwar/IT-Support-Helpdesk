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
        private readonly CaseRepository caseRepository;
        private readonly ConvertationRepository convertationRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly HistoryRepository historyRepository;
        private readonly PriorityRepository priorityRepository;
        private readonly RoleRepository roleRepository;
        private readonly StatusCodeRepository statusCodeRepository;
        private readonly AttachmentRepository attachmentRepository;
        public PanelController(
            UserRepository userRepository,
            CaseRepository caseRepository,
            ConvertationRepository convertationRepository,
            CategoryRepository categoryRepository,
            HistoryRepository historyRepository,
            PriorityRepository priorityRepository,
            RoleRepository roleRepository,
            StatusCodeRepository statusCodeRepository,
            AttachmentRepository attachmentRepository
            ) : base(userRepository)
        {
            this.userRepository = userRepository;
            this.caseRepository = caseRepository;
            this.convertationRepository = convertationRepository;
            this.categoryRepository = categoryRepository;
            this.historyRepository = historyRepository;
            this.priorityRepository = priorityRepository;
            this.roleRepository = roleRepository;
            this.statusCodeRepository = statusCodeRepository;
            this.attachmentRepository = attachmentRepository;
        }

        public void GetSession()
        {
            ViewBag.UserId = HttpContext.Session.GetString("UserId");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
        }

        public IActionResult Users()
        {
            GetSession();
            return View();
        }

        public async Task<JsonResult> GetUsers()
        {
            GetSession();
            var result = await userRepository.GetUsers();
            return Json(result);
        }

        public async Task<JsonResult> GetCases()
        {
            GetSession();
            var result = await caseRepository.GetCases();
            return Json(result);
        }

        public async Task<JsonResult> GetConvertations()
        {
            GetSession();
            var result = await convertationRepository.GetConvertations();
            return Json(result);
        }

        public async Task<JsonResult> GetCategories()
        {
            GetSession();
            var result = await categoryRepository.GetCategories();
            return Json(result);
        }

        public async Task<JsonResult> GetHistories()
        {
            GetSession();
            var result = await historyRepository.GetHistories();
            return Json(result);
        }

        public async Task<JsonResult> GetPriorities()
        {
            GetSession();
            var result = await priorityRepository.GetPriorities();
            return Json(result);
        }

        public async Task<JsonResult> GetRoles()
        {
            GetSession();
            var result = await roleRepository.GetRoles();
            return Json(result);
        }

        public async Task<JsonResult> GetStatusCodes()
        {
            GetSession();
            var result = await statusCodeRepository.GetStatusCodes();
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
            GetSession();
            return View();
        }

        public IActionResult Cases()
        {
            GetSession();
            return View();
        }

        public IActionResult Convertations()
        {
            GetSession();
            return View();
        }

        public IActionResult Attachments()
        {
            GetSession();
            return View();
        }

        public IActionResult Histories()
        {
            GetSession();
            return View();
        }

        public IActionResult Categories()
        {
            GetSession();
            return View();
        }

        public IActionResult StatusCodes()
        {
            GetSession();
            return View();
        }

        public IActionResult Priorities()
        {
            GetSession();
            return View();
        }

        public IActionResult Roles()
        {
            GetSession();
            return View();
        }

        public IActionResult CreateTicket()
        {
            GetSession();
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
