using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class AvatarVM
    {
        public int UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
