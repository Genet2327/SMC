using Newtonsoft.Json;
using SMC_UI.Models.Course;
using SMC_UI.Models.Role;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseReadDto>> GetAll(string token);
        Task<CourseCreateDto> Create(CourseCreateDto model, string token);
        Task<CourseUpdateDto> Update(CourseUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<CourseReadDto> GetById(int id, string token);
    }
    public class CourseService : ICourseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CourseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<CourseReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"course";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<CourseReadDto>>() ?? new List<CourseReadDto>();
        }

        public async Task<CourseCreateDto> Create(CourseCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"course";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<CourseCreateDto>() ?? new CourseCreateDto();
        }

        public async Task<CourseReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Course/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<CourseReadDto>() ?? new CourseReadDto();
        }

        public async Task<CourseUpdateDto> Update(CourseUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Course/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<CourseUpdateDto>() ?? new CourseUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Course/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
