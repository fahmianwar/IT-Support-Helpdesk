using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IStatusCode
    {
        IEnumerable<StatusCode> Get();
        StatusCode Get(int id);
        int Insert(StatusCode statusCode);
        int Update(StatusCode statusCode);
        int Delete(int id);
    }
}
