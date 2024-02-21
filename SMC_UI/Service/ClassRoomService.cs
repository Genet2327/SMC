using Newtonsoft.Json;
using SMC_UI.Models.ClassRoom;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface IClassRoomService
    {
        Task<IEnumerable<ClassRoomReadDto>> GetAll(string token);
        Task<ClassRoomCreateDto> Create(ClassRoomCreateDto model, string token);
        Task<ClassRoomUpdateDto> Update(ClassRoomUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<ClassRoomReadDto> GetById(int id, string token);
        Task<IEnumerable<StudentRedByClassRoomNumberDto>> GetAllStudentById(int id, string token);
    }
    public class ClassRoomService : IClassRoomService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ClassRoomService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ClassRoomReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"ClassRoom";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<ClassRoomReadDto>>() ?? new List<ClassRoomReadDto>();
        }

        public async Task<ClassRoomCreateDto> Create(ClassRoomCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"ClassRoom";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ClassRoomCreateDto>() ?? new ClassRoomCreateDto();
        }

        public async Task<ClassRoomReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"ClassRoom/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ClassRoomReadDto>() ?? new ClassRoomReadDto();
        }

        public async Task<IEnumerable<StudentRedByClassRoomNumberDto>> GetAllStudentById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"ClassRoom/AllStudent/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<StudentRedByClassRoomNumberDto>>();
        }

        public async Task<ClassRoomUpdateDto> Update(ClassRoomUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"ClassRoom/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ClassRoomUpdateDto>() ?? new ClassRoomUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"ClassRoom/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
