using Newtonsoft.Json;
using SMC_UI.Models.Exam;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface IExamService
    {
        Task<IEnumerable<ExamReadDto>> GetAll(string token);
        Task<ExamCreateDto> Create(ExamCreateDto model, string token);
        Task<ExamUpdateDto> Update(ExamUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<ExamReadDto> GetById(int id, string token);
    }
    public class ExamService : IExamService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ExamService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ExamReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Exam";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<ExamReadDto>>() ?? new List<ExamReadDto>();
        }

        public async Task<ExamCreateDto> Create(ExamCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Exam";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ExamCreateDto>() ?? new ExamCreateDto();
        }

        public async Task<ExamReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Exam/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ExamReadDto>() ?? new ExamReadDto();
        }

        public async Task<ExamUpdateDto> Update(ExamUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Exam/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ExamUpdateDto>() ?? new ExamUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Exam/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
