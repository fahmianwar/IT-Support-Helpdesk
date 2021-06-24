using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IHistory
    {
        IEnumerable<History> Get();
        History Get(int id);
        int Insert(History history);
        int Update(History history);
        int Delete(int id);
    }
}
