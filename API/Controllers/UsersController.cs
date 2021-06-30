using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository userRepository;
        public UsersController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
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

        [HttpPost("CreateUser")]
        public ActionResult CreateUser(User user)
        {
            var create = userRepository.CreateUser(user);
            if (create > 0)
            {
                return Ok("Register Berhasil");
            }
            else
            {
                return BadRequest("Register Gagal");
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = userRepository.Login(loginVM);
            if (login == 404)
            {
                return BadRequest("Email tidak ditemukan, Silakan gunakan email lain");
            }
            else if (login == 401)
            {
                return BadRequest("Password salah");
            }
            else if (login == 1)
            {
                return Ok(
                    new JWTokenVM
                    {
                        Token = userRepository.GenerateTokenLogin(loginVM),
                        Messages = "Login Success"
                    }
                    );

            }
            else
            {
                return BadRequest("Gagal login");
            }
        }

        [HttpGet("GetUserByEmail/{email}")]
        public ActionResult GetUserByEmail(string email)
        {
            var get = userRepository.GetUserByEmail(email);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetClients")]
        public ActionResult GetClients()
        {
            var get = userRepository.GetClients();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }

        }

        [Authorize(Roles = "Admin, Software Developer, IT Support, Customer Service")]
        [HttpGet("GetClientbyId/{id}")]
        public ActionResult GetClientbyId(int id)
        {
            var get = userRepository.GetClientById(id);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("DeleteClientById/{id}")]
        public ActionResult DeleteClientById(int id)
        {
            var get = userRepository.DeleteClientById(id);
            if (get != 0)
            {
                return Ok("Data Berhasil Dihapus");
            }
            else
            {
                return BadRequest("Data Gagal Dihapus");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetStaffs")]
        public ActionResult GetStaffs()
        {
            var get = userRepository.GetStaffs();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetStaffbyId/{id}")]
        public ActionResult GetStaffbyId(int id)
        {
            var get = userRepository.GetStaffById(id);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("DeleteStaffById/{id}")]
        public ActionResult DeleteStaffById(int id)
        {
            var get = userRepository.DeleteStaffById(id);
            if (get != 0)
            {
                return Ok("Data Berhasil Dihapus");
            }
            else
            {
                return BadRequest("Data Gagal Dihapus");
            }
        }

    }
}