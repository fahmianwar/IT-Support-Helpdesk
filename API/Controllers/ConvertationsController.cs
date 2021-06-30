using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
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
        private readonly AttachmentRepository attachmentRepository;
        public ConvertationsController(ConvertationRepository convertationRepository, AttachmentRepository attachmentRepository) : base(convertationRepository)
        {
            this.convertationRepository = convertationRepository;
            this.attachmentRepository = attachmentRepository;
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

        [HttpPost("CreateConvertations")]
        public ActionResult CreateConvertation(CreateConvertationVM createConvertationVM)
        {
            //var createConvertationVM = new CreateConvertationVM()
            //{
            //    UserId = userId,
            //    CaseId = caseId,
            //    Message = message
            //};
            var post = convertationRepository.CreateConvertation(createConvertationVM);
            if (post > 0)
            {
                //var convertationId = post;
                //var description = createConvertationVM.Message;
                //var upload = attachmentRepository.UploadToFileSystem(createConvertationVM.Files, convertationId, description);
                //if (upload > 0)
                //{
                    return Ok("Berhasil membuat Tiket");
                //}
                //else
                //{
                //    return BadRequest("Gagal mengunggah Attachment Tiket");
                //}
            }

            else
            {
                return BadRequest("Gagal membuat Tiket");
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

        [HttpGet("ViewConvertationsByUserId/{id}")]
        public ActionResult ViewConvertationsByUserId(int id)
        {
            var get = convertationRepository.ViewConvertationsByUserId(id);
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