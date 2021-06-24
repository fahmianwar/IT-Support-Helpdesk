using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IUser
    {
        IEnumerable<User> Get();
        User Get(int id);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
    }
}
