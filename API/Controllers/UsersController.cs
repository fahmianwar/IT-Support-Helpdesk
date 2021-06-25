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
    [Route("api/[controller]")]
    public class UsersController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository userRepository;
        public UsersController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }
        [Route("Register")]
        [HttpPost]
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
        [Route("Login")]
        [HttpPost]
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
        [Route("GetCLient")]
        [HttpGet]
        public ActionResult GetAllClient()
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
        [Route("GetClientbyId/{id}")]
        [HttpGet]
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
        [Route("DeleteClientById/{id}")]
        [HttpPost]
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
        [Route("GetStaff")]
        [HttpGet]
        public ActionResult GetAllStaff()
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
        [Route("GetStaffbyId/{id}")]
        [HttpGet]
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
        [Route("DeleteStaffById/{id}")]
        [HttpPost]
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