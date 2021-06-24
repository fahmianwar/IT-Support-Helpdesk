using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IAttachment
    {
            IEnumerable<Attachment> Get();
            Attachment Get(int id);
            int Insert(Attachment attachment);
            int Update(Attachment attachment);
            int Delete(int id);
    }
}
