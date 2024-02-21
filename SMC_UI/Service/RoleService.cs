using Newtonsoft.Json;
using SMC_UI.Models.Account;
using SMC_UI.Models.Role;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleReadDto>> GetAll(string token);
        Task<RoleCreateDto> Create(RoleCreateDto model, string token);
        Task<RoleUpdateDto> Update(RoleUpdateDto model, string token);
        Task Delete(string id, string token);
        Task<RoleReadDto> GetById(string id, string token);
        Task<string> AddRole(AddRoleModel model, string token);
    }
    public class RoleService : IRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<RoleReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Role";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<RoleReadDto>>() ?? new List<RoleReadDto>();
        }

        public async Task<RoleCreateDto> Create(RoleCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Role";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<RoleCreateDto>() ?? new RoleCreateDto();
        }

        public async Task<string> AddRole(AddRoleModel model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Account/addrole";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<string>();
        }

        public async Task<RoleReadDto> GetById(string id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Role/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<RoleReadDto>() ?? new RoleReadDto();
        }

        public async Task<RoleUpdateDto> Update(RoleUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Role/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<RoleUpdateDto>() ?? new RoleUpdateDto();
        }
        public async Task Delete(string id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Role/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
