using Newtonsoft.Json;
using SMC_API.Dtos.Quote;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{

    public interface IQuoteService
    {
        Task<IEnumerable<QuoteReadDto>> GetAll(string token);
        Task<QuoteCreateDto> Create(QuoteCreateDto model, string token);
        Task<QuoteUpdateDto> Update(QuoteUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<QuoteReadDto> GetById(int id, string token);
    }
    public class QuoteService : IQuoteService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public QuoteService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<QuoteReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Quote";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<QuoteReadDto>>() ?? new List<QuoteReadDto>();
        }

        public async Task<QuoteCreateDto> Create(QuoteCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Quote";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<QuoteCreateDto>() ?? new QuoteCreateDto();
        }

        public async Task<QuoteReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Quote/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<QuoteReadDto>() ?? new QuoteReadDto();
        }

        public async Task<QuoteUpdateDto> Update(QuoteUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Quote/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<QuoteUpdateDto>() ?? new QuoteUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Quote/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }


}
