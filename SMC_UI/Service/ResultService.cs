using Newtonsoft.Json;
using SMC_UI.Dtos.Result;
using SMC_UI.Models.Result;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMC_UI.Service
{
    public interface IResultService
    {
        Task<IEnumerable<ResulReadDto>> GetAll(string token);
        Task<ResultCreateDto> Create(ResultCreateDto model, string token);
        Task<ResultUpdateDto> Update(ResultUpdateDto model, string token);
        Task Delete(int? id, string token);
        Task<ResulReadDto> GetById(int id, string token);
        Task<IEnumerable<ResultGroupByStudentIdVm>> GetByStudentId(int studentId, string token);
    }
    public class ResultService : IResultService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ResultService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ResulReadDto>> GetAll(string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Result";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<ResulReadDto>>() ?? new List<ResulReadDto>();
        }

        public async Task<IEnumerable<ResultGroupByStudentIdVm>> GetByStudentId(int studentId, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Result/GetByStudentId/{studentId}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<ResultGroupByStudentIdVm>>() ?? new List<ResultGroupByStudentIdVm>();
        }

        public async Task<ResultCreateDto> Create(ResultCreateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Result";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ResultCreateDto>() ?? new ResultCreateDto();
        }

        public async Task<ResulReadDto> GetById(int id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Result/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ResulReadDto>() ?? new ResulReadDto();
        }

        public async Task<ResultUpdateDto> Update(ResultUpdateDto model, string token)
        {
            var content = JsonConvert.SerializeObject(model);
            var url = $"Result/{model.Id}";
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.Default, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ResultUpdateDto>() ?? new ResultUpdateDto();
        }
        public async Task Delete(int? id, string token)
        {
            var httpClient = _httpClientFactory.CreateClient("SMC_API");
            var url = $"Result/{id}";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}

