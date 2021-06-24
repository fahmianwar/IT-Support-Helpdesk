using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        private readonly MyContext context;
        private readonly DbSet<RegisterVM> registers;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
            registers = context.Set<RegisterVM>();
        }
        public int Register (RegisterVM registerVM)
        {
            var result = 0;
            var cek = context.Users.FirstOrDefault(u => u.Email == registerVM.Email);
            if (cek== null)
            {
                User user = new User()
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    BirthDate
                }
            }
        }
    }
}
