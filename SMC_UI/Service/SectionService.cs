using Newtonsoft.Json;
using SMC_UI.Dtos.Section;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionReadDto>> GetAll(string token);
        Task<SectionCreateDto> Create(SectionCreateDto model, string token);
        Task<SectionUpdateDto> Update(SectionUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<SectionReadDto> GetById(int id, string token);
    }
    public class SectionService : ISectionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SectionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<SectionReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Section";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<SectionReadDto>>() ?? new List<SectionReadDto>();
        }

        public async Task<SectionCreateDto> Create(SectionCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Section";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<SectionCreateDto>() ?? new SectionCreateDto();
        }

        public async Task<SectionReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Section/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<SectionReadDto>() ?? new SectionReadDto();
        }

        public async Task<SectionUpdateDto> Update(SectionUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Section/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<SectionUpdateDto>() ?? new SectionUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Section/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
