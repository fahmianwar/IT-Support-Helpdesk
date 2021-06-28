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
        
        [HttpPost("Upload")]
        public ActionResult UploadToFileSystem(List<IFormFile> files, int convertationId, string description)
        {
            var upload = attachmentRepository.UploadToFileSystem(files, convertationId, description);
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
        public IActionResult DownloadFileFromFileSystem(int id)
        {
            var file = attachmentRepository.Get(id);
            if (file == null) return BadRequest();
            /*
            var memory = new MemoryStream();
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
            var filePath = Path.Combine(basePath, file.Name);
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Name + file.Extension);
            */
            var stream = new FileStream(Directory.GetCurrentDirectory() + "\\Files\\" + file.Name, FileMode.Open);
            return new FileStreamResult(stream, file.FileType);
        }

    }
}
