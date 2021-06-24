using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ClientRepository : GeneralRepository<MyContext, Client, int>
    {
        public ClientRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
