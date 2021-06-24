using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface ICase
    {
        IEnumerable<Case> Get();
        Case Get(int id);
        int Insert(Case caseVar);
        int Update(Case caseVar);
        int Delete(int id);
    }
}
