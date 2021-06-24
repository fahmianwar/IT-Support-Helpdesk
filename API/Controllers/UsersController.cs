using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository userRepository;
        public UsersController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost("Register")]
        public ActionResult Register (RegisterVM registerVM)
        {
            var register = userRepository.Register(registerVM);
            if (register > 0)
            {
                return Ok("Register Berhasil");
            }
            else
            {
                return BadRequest("Register Gagal");
            }
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var post = userRepository.Login(loginVM);
            if (post > 0)
            {
                return Ok("Berhasil Login");
            }
            else
            {
                return BadRequest("Gagal Login");
            }
        }
    }
}