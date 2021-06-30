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

        public IActionResult Users()
        {
            return View();
        }

        public async Task<JsonResult> GetUsers()
        {
            var result = await userRepository.GetUsers();
            return Json(result);
        }

        public async Task<JsonResult> GetCases()
        {
            var result = await caseRepository.GetCases();
            return Json(result);
        }

        public async Task<JsonResult> GetConvertations()
        {
            var result = await convertationRepository.GetConvertations();
            return Json(result);
        }

        public async Task<JsonResult> GetCategories()
        {
            var result = await categoryRepository.GetCategories();
            return Json(result);
        }

        public async Task<JsonResult> GetHistories()
        {
            var result = await historyRepository.GetHistories();
            return Json(result);
        }

        public async Task<JsonResult> GetPriorities()
        {
            var result = await priorityRepository.GetPriorities();
            return Json(result);
        }

        public async Task<JsonResult> GetRoles()
        {
            var result = await roleRepository.GetRoles();
            return Json(result);
        }

        public async Task<JsonResult> GetStatusCodes()
        {
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

        public IActionResult Priorities()
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
