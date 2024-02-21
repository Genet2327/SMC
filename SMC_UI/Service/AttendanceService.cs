using Newtonsoft.Json;
using SMC_UI.Models.Attendance;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceReadDto>> GetAll(string token);
        Task<AttendanceCreateDto> Create(AttendanceCreateDto model, string token);
        Task<AttendanceUpdateDto> Update(AttendanceUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<AttendanceReadDto> GetById(int id, string token);
        Task<IEnumerable<AttendanceReadDto>> GetByStudentId(int studentId, string token);
    }

    public class AttendanceService : IAttendanceService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AttendanceService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<AttendanceReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Attendance";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<AttendanceReadDto>>() ?? new List<AttendanceReadDto>();
        }

        public async Task<IEnumerable<AttendanceReadDto>> GetByStudentId(int studentId, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Attendance/GetByStudentId/{studentId}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<AttendanceReadDto>>() ?? new List<AttendanceReadDto>();
        }

        public async Task<AttendanceCreateDto> Create(AttendanceCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Attendance";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AttendanceCreateDto>() ?? new AttendanceCreateDto();
        }

        public async Task<AttendanceReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Attendance/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AttendanceReadDto>() ?? new AttendanceReadDto();
        }

        public async Task<AttendanceUpdateDto> Update(AttendanceUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Attendance/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AttendanceUpdateDto>() ?? new AttendanceUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Attendance/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
