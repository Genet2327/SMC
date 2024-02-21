using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using SMC_API.Dtos.Student;
using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Paged;
using SMC_Entities.ViewModel;
using System;
using System.Collections.Generic;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<StudentReadDto>> GetAll([FromQuery] QueryStringParameters parameters)
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
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult<StudentReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(model));
            }
            return NotFound();
        }

        [HttpPost("")]
        public ActionResult<StudentReadDto> Create(StudentCreateDto vm)
        {
            var model = _mapper.Map<Student>(vm);
            _repository.Create(model);
            var readDto = _mapper.Map<StudentReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, StudentUpdateDto vm)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            _mapper.Map(vm, model);
            _repository.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            _repository.Delete(model);
            return NoContent();
        }
    }
}
