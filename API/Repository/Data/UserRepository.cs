using API.Context;
using API.Models;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
        SmtpClient client = new SmtpClient();
        ServiceEmail serviceEmail = new ServiceEmail();
        public int UploadToFileSystem([FromForm] AvatarVM avatarVM)
        {
            int result = 0;
                
                var guid = Guid.NewGuid().ToString();
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Avatars\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(avatarVM.File.FileName);
                var filePath = Path.Combine(basePath, guid);
                var extension = Path.GetExtension(avatarVM.File.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    var stream = new FileStream(filePath, FileMode.Create);
                    avatarVM.File.CopyToAsync(stream);
                    stream.Close();
                    var user = context.Users.Find(avatarVM.UserId);
                    user.Avatar = guid;
                    context.Users.Update(user);
                    result = context.SaveChanges();
                }
            return result;
        }
        public int Register(RegisterVM registerVM)
        {
            var message = "Your register in IT Support Helpdesk is Successfull!!";
            serviceEmail.SendEmail(registerVM.Email, message);
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
                    Avatar = "avatar-default",
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
            var user = context.Users.FirstOrDefault(p => p.Email == loginVM.Email);
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

        public UserSessionVM GetUserByEmail(string Email)
        {
            var all = (
               from u in context.Users
               join r in context.Roles on u.RoleId equals r.Id
               select new UserSessionVM
               {
                   UserId = u.Id,
                   Name = u.Name,
                   Email = u.Email,
                   Role = r.Name,
                   RoleId = r.Id
               }).ToList();
            return all.FirstOrDefault(u => u.Email == Email);
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
        //Profile
        public IEnumerable<ProfileVM> GetProfile()
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
            return all;
        }
        // Users
        public int UpdateProfile(User updateUser)
        {
            var result = 0;
            var user = context.Users.FirstOrDefault(u => u.Email == updateUser.Email);
            if (user != null)

            {

                    user.Name = updateUser.Name;
                    user.BirthDate = updateUser.BirthDate;
                    user.Phone = updateUser.Phone;
                    user.Address = updateUser.Address;
                    user.Department = updateUser.Department;
                    user.Company = updateUser.Company;

                if (updateUser.Password != "")
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(updateUser.Password);
                }
                context.Users.Update(user);
                result = context.SaveChanges();
            }
            return result;
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
