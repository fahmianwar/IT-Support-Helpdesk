using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Data;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        UserRepository repository;
        public RegisterController(UserRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
