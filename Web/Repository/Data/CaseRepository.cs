using API.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Base;

namespace Web.Repository.Data
{
    public class CaseRepository : GeneralRepository<Case, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public CaseRepository(Address address, string request = "Cases/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<Case>> GetCases()
        {
            List<Case> data = new List<Case>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<Case>>(apiResponse);
            }
            return data;
        }

        public async Task<List<Case>> GetTicketsByUserId(int userId)
        {
            List<Case> data = new List<Case>();

            using (var response = await httpClient.GetAsync(request + "ViewTicketsByUserId/" + userId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<Case>>(apiResponse);
            }
            return data;
        }
    }
}
