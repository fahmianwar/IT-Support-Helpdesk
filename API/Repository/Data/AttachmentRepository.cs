using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AttachmentRepository : GeneralRepository<MyContext, Attachment, int>
    {
        public AttachmentRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
