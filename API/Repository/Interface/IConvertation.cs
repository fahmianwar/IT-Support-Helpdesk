using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IConvertation
    {
        IEnumerable<Convertation> Get();
        Convertation Get(int id);
        int Insert(Convertation convertation);
        int Update(Convertation convertation);
        int Delete(int id);
    }
}
