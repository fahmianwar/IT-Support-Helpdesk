using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
