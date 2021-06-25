using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AttachmentRepository : GeneralRepository<MyContext, Attachment, int>
    {
        private readonly MyContext context;
        public IConfiguration Configuration;
        public AttachmentRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.context = myContext;
            Configuration = configuration;
        }

        public int UploadToFileSystem(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.Name);
                var filePath = Path.Combine(basePath, file.Name);
                var extension = Path.GetExtension(file.Name);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                    var fileModel = new Attachment
                    {
                        CreatedOn = DateTime.Now,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = fileName,
                        Description = ""
                    };
                    context.Attachments.Add(fileModel);
                    context.SaveChanges();
                }
            }
            return context.SaveChanges();
        }

    }
}
