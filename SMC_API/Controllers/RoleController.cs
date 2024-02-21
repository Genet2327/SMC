using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMC_API.Models.Role;
using SMC_Contracts;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;

        public RoleController(IMapper mapper, IRoleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<RoleReadDto>> GetAll([FromQuery] QueryStringParameters parameters)
        {
            var model = _repository.GetAll(parameters);
            var metadata = new
            {
                model.TotalCount,
                model.PageSize,
                model.CurrentPage,
                model.TotalPages,
                model.HasNext,
                model.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult<RoleReadDto> GetById(string id)
        {            
            var model = _repository.GetById(id).Result;
            if (model != null)
            {
                return Ok(_mapper.Map<RoleReadDto>(model));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<RoleReadDto>> Create(RoleCreateDto vm)
        {
            var model = _mapper.Map<IdentityRole>(vm);
            _repository.Create(model);
            var readDto = _mapper.Map<RoleReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, RoleUpdateDto vm)
        {
            var model = _repository.GetById(id).Result;
            if (model == null)
            {
                return NotFound();
            }
            _mapper.Map(vm, model);
            _repository.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var model = _repository.GetById(id).Result;
            if (model == null)
            {
                return NotFound();
            }
            _repository.Delete(model);
            return NoContent();
        }
    }
}
