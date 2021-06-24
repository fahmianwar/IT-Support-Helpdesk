using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        private readonly MyContext context;
        private readonly DbSet<RegisterVM> entities;
        public IConfiguration Configuration;
        public UserRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.context = myContext;
            entities = context.Set<RegisterVM>();
            Configuration = configuration;
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
                    Password = BCrypt.Net.HashPassword(registerVM.Password),
                    BirthDate = registerVM.BirthDate,
                    RoleId = registerVM.RoleId
                };
                context.Add(user);
                result = context.SaveChanges();

                Client client = new Client()
                {
                    Phone = registerVM.Phone,
                    Address = registerVM.Address,
                    Department = registerVM.Department,
                    Company = registerVM.Company
                };
                context.Add(client);
                result = context.SaveChanges();
            }
            return result;
        }
        public string GenerateTokenLogin(LoginVM loginVM)
        {
            var user = context.Users.Single(p => p.Email == loginVM.Email);
            var ar = context.Roles.Single(ar => ar.Id == user.RoleId);
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, Configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("NIK", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("role",ar.Name)
                    //new Claim(ClaimTypes.Role,ar.Role.RoleName)
                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public int Login(LoginVM loginVM)
        {
            var cek = context.Users.FirstOrDefault(u => u.Email == loginVM.Email);
            if (cek.Password == loginVM.Password)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
