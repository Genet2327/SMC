using Newtonsoft.Json;
using SMC_UI.Models.Student;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentReadDto>> GetAll(string token);
        Task<StudentCreateDto> Create(StudentCreateDto model, string token);
        Task<StudentUpdateDto> Update(StudentUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<StudentReadDto> GetById(int id, string token);
        //void CreateStudent(StudentCreateDto stu);
    }

    public class StudentService : IStudentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StudentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<StudentReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"student";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<StudentReadDto>>() ?? new List<StudentReadDto>();
        }

        public async Task<StudentCreateDto> Create(StudentCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"student";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<StudentCreateDto>() ?? new StudentCreateDto();
        }

        public async Task<StudentReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"student/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<StudentReadDto>() ?? new StudentReadDto();
        }

        public async Task<StudentUpdateDto> Update(StudentUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"student/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<StudentUpdateDto>() ?? new StudentUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"student/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
