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
    public class CasesController : BaseController<Case, CaseRepository, int>
    {
        private readonly CaseRepository caseRepository;
        public CasesController(CaseRepository caseRepository) : base(caseRepository)
        {
            this.caseRepository = caseRepository;
        }

        [HttpPost("CreateTicket")]
        public ActionResult CreateTicket(TicketVM ticketVM)
        {
            var create = caseRepository.CreateTicket(ticketVM);
            if (create > 0)
            {
                return Ok("Tiket Berhasil Ditambahkan");
            }
            else
            {
                return BadRequest("Tiket Gagal Ditambahkan");
            }
        }

        [HttpGet("ViewTicketsByUserId/{userId}")]
        public ActionResult ViewTicketsByUserId(int userId)
        {
            var get = caseRepository.ViewTicketsByUserId(userId);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data tidak ditemukan");
            }
        }

        [HttpGet("ViewTicketsByLevel/{level}")]
        public ActionResult ViewTicketsByLevel(int level)
        {
            var get = caseRepository.ViewTicketsByLevel(level);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Tiket Gagal Ditutup");
            }
        }

        [HttpPost("AskNextLevel")]
        public ActionResult AskNextLevel(int caseId)
        {
            var ask = caseRepository.AskNextLevel(caseId);
            if (ask > 0)
            {
                return Ok("Berhasil meminta bantuan");
            }
            else
            {
                return BadRequest("Gagal meminta bantuan");
            }
        }

        [HttpPost("CloseTicket")]
        public ActionResult CloseTicketById(CloseTicketVM closeTicketVM)
        {
            var create = caseRepository.CloseTicketById(closeTicketVM);
            if (create > 0)
            {
                return Ok("Tiket Berhasil Ditutup");
            }
            else
            {
                return BadRequest("Tiket Gagal Ditutup");
            }
        }

        [HttpPost("ReviewTicket")]
        public ActionResult CloseTicketById(ReviewTicketVM reviewTicketVM)
        {
            var create = caseRepository.ReviewTicket(reviewTicketVM);
            if (create > 0)
            {
                return Ok("Tiket Berhasil Ditutup");
            }
            else
            {
                return BadRequest("Tiket Gagal Ditutup");
            }
        }
    }
}
