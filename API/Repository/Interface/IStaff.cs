using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IStaff
    {
        IEnumerable<Staff> Get();
        Staff Get(int id);
        int Insert(Staff staff);
        int Update(Staff staff);
        int Delete(int id);
    }
}
