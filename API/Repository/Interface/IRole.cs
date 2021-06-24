using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IRole
    {
        IEnumerable<Role> Get();
        Role Get(int id);
        int Insert(Role priority);
        int Update(Role priority);
        int Delete(int id);
    }
}
