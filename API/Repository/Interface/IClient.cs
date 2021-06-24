using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IClient
    {
        IEnumerable<IClient> Get();
        IClient Get(int id);
        int Insert(IClient client);
        int Update(IClient client);
        int Delete(int id);
    }
}
