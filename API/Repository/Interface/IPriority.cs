using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IPriority
    {
        IEnumerable<Priority> Get();
        Priority Get(int id);
        int Insert(Priority priority);
        int Update(Priority priority);
        int Delete(int id);
    }
}
