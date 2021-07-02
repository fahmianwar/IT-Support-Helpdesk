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
            if (cek == null)
            {
                User user = new User()
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password),
                    BirthDate = registerVM.BirthDate,
                    RoleId = 5,
                    Phone = registerVM.Phone,
                    Address = registerVM.Address,
                    Department = registerVM.Department,
                    Company = registerVM.Company
                };
                context.Add(user);
                result = context.SaveChanges();
            }
            return result;
        }

        public int CreateUser(User user)
        {
            var cek = context.Users.FirstOrDefault(u => u.Email == user.Email);
            if(cek == null)
            {
                context.Add(user);
                return context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        public string GenerateTokenLogin(LoginVM loginVM)
        {
            var user = context.Users.Single(p => p.Email == loginVM.Email);
            var ar = context.Roles.Single(ar => ar.Id == user.RoleId);
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, Configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
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
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public int Login(LoginVM loginVM)
        {
            var cek = context.Users.FirstOrDefault(u => u.Email == loginVM.Email);
            if (cek == null)
            {
                return 404;
            }

            if (BCrypt.Net.BCrypt.Verify(loginVM.Password, cek.Password))
            {
                return 1;
            }
            else
            {
                return 401;
            }
        }

        public User GetUserByEmail(string email)
        {
            var cek = context.Users.FirstOrDefault(u => u.Email == email);
            return cek;
        }

        // Clients
        public IEnumerable<ProfileVM> GetClients()
        {
            User user = new User();
            var all = (
                from u in context.Users
                join r in context.Roles on u.RoleId equals r.Id
                select new ProfileVM
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    BirthDate = u.BirthDate,
                    RoleName = r.Name,
                    Phone = u.Phone,
                    Address = u.Address,
                    Department = u.Department,
                    Company = u.Company,
                    Detail = u.Detail
                }).ToList();
            return all.Where(x => x.RoleName == "Client");
        }
        public ProfileVM GetClientById(int id)
        {
            var all = (
                from u in context.Users
                join r in context.Roles on u.RoleId equals r.Id
                select new ProfileVM
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    BirthDate = u.BirthDate,
                    RoleName = r.Name,
                    Phone = u.Phone,
                    Address = u.Address,
                    Department = u.Department,
                    Company = u.Company,
                    Detail = u.Detail
                }).ToList();
            return all.FirstOrDefault(u => u.Id == id);
        }
        public int DeleteClientById(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // Staffs
        public IEnumerable<ProfileVM> GetStaffs()
        {
            User user = new User();
            var all = (
                from u in context.Users
                join r in context.Roles on u.RoleId equals r.Id
                select new ProfileVM
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    BirthDate = u.BirthDate,
                    RoleName = r.Name,
                    Phone = u.Phone,
                    Address = u.Address,
                    Department = u.Department,
                    Company = u.Company,
                    Detail = u.Detail
                }).ToList();
            return all.Where(x => x.RoleName != "Client");
        }
        public ProfileVM GetStaffById(int id)
        {
            var all = (
               from u in context.Users
               join r in context.Roles on u.RoleId equals r.Id
               select new ProfileVM
               {
                   Id = u.Id,
                   Name = u.Name,
                   Email = u.Email,
                   BirthDate = u.BirthDate,
                   RoleName = r.Name,
                   Phone = u.Phone,
                   Address = u.Address,
                   Department = u.Department,
                   Company = u.Company,
                   Detail = u.Detail
               }).ToList();
            return all.FirstOrDefault(u => u.Id == id);
        }

        public int DeleteStaffById(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // Users
        public int UpdateProfile(ProfileVM profile)
        {
            
            return 0;
        }
        public List<User> GetUsers()
        {
            return new List<User>();
        }
        public User GetUserById(int id)
        {
            return new User();
        }
        public int UpdateUser(User user)
        {
            return 0;
        }
        public int DeleteUserById(int id)
        {
            return 0;
        }
    }
}
