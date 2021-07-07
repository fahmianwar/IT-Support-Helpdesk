using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Base;

namespace Web.Repository.Data
{
    public class UserRepository : GeneralRepository<User, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserRepository(Address address, string request = "Users/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<JWTokenVM> Auth(LoginVM loginVM)
        {
            JWTokenVM token = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request + "Login", content);

            if (result.IsSuccessStatusCode)
            {
                string apiResponse = await result.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);
            }
            return token;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> data = new List<User>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<User>>(apiResponse);
            }
            return data;
        }

        public HttpStatusCode InsertUser(User user)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request, content).Result;
            return result.StatusCode;
        }

        public async Task<RegisterVM> GetProfileById(int id)
        {
            RegisterVM entity = null;

            using (var response = await httpClient.GetAsync(request + "GetProfileById/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return entity;
        }

        public async Task<UserSessionVM> GetUserByEmail(string email)
        {
            UserSessionVM entity = null;

            using (var response = await httpClient.GetAsync(request + "GetUserByEmail/" + email))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<UserSessionVM>(apiResponse);
            }
            return entity;
        }

    }
}
