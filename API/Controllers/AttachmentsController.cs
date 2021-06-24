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
    public class AttachmentsController : BaseController<Attachment, AttachmentRepository, int>
    {
        private readonly AttachmentRepository attachmentRepository;
        public AttachmentsController(AttachmentRepository attachmentRepository) : base(attachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
        }
    }
}
