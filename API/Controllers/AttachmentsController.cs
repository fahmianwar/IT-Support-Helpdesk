using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AttachmentsController : BaseController<Attachment, AttachmentRepository, int>
    {
        private readonly AttachmentRepository attachmentRepository;
        public AttachmentsController(AttachmentRepository attachmentRepository) : base(attachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
        }
        
        [HttpPost("Upload/{files}")]
        public ActionResult UploadToFileSystem(List<IFormFile> files)
        {
            var upload = attachmentRepository.UploadToFileSystem(files);
            if (upload > 0)
            {
                return Ok("Berkas berhasil diunggah");
            }
            else
            {
                return BadRequest("Berkas gagal diunggah");
            }
        }

        [HttpGet("Download/{id}")]
        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = attachmentRepository.Get(id);
            if (file == null) return BadRequest();
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.Name, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Name + file.Extension);
        }

    }
}
