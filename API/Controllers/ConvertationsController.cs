using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ConvertationsController : BaseController<Convertation, ConvertationRepository, int>
    {
        private readonly ConvertationRepository convertationRepository;
        public ConvertationsController(ConvertationRepository convertationRepository) : base(convertationRepository)
        {
            this.convertationRepository = convertationRepository;
        }

        [HttpGet("ViewConvertations")]
        public ActionResult ViewConvertations()
        {
            var get = convertationRepository.ViewConvertations();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }

        }

        [HttpGet("ViewConvertationsByCaseId/{id}")]
        public ActionResult ViewConvertationsByCaseId(int id)
        {
            var get = convertationRepository.ViewConvertationsByCaseId(id);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }

        }
    }
}