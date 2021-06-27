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

        public int UploadToFileSystem(List<IFormFile> files, int convertationId, string description)
        {
            int result = 0;
            foreach (var file in files)
            {
                var guid = Guid.NewGuid().ToString();
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, guid);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    var stream = new FileStream(filePath, FileMode.Create);
                    file.CopyToAsync(stream);
                    var fileModel = new Attachment
                    {
                        CreatedOn = DateTime.Now,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = guid,
                        Description = description,
                        ConvertationId = convertationId
                    };
                    context.Add(fileModel);
                    result = context.SaveChanges();
                }
            }
            return result;
        }

    }
}
