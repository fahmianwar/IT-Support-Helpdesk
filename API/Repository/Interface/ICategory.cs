using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface ICategory
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        int Insert(Category category);
        int Update(Category category);
        int Delete(int id);
    }
}
