using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SMC_UI.Models;
using SMC_UI.Models.Account;
using SMC_UI.Models.Role;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface IAccountService
    {
        Task<AuthenticationModel> Login(Login att);
        Task<RegisterModel> Register(Register rtt);
        Task<string> CreateRole(RoleCreateDto model, string token);
    }

    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> CreateRole(RoleCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);

            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            using var response = await httpClient.PostAsync("Account/createrole", new StringContent(content, Encoding.Default, "application/json"));

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<AuthenticationModel> Login(Login model)
        {
            var content = JsonConvert.SerializeObject(model);

            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            using var response = await httpClient.PostAsync("Account/login", new StringContent(content, Encoding.Default, "application/json"));

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<AuthenticationModel>(await response.Content.ReadAsStringAsync());
            return result;
        }
        public async Task<RegisterModel> Register(Register model)
        {
            var content = JsonConvert.SerializeObject(model);

            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            using var response = await httpClient.PostAsync("Account/Register", new StringContent(content, Encoding.Default, "application/json"));

            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<RegisterModel>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}
