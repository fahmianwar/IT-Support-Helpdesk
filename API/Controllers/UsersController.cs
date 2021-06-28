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