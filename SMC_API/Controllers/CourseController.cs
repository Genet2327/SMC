using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMC_API.Dtos.Course;
using SMC_Contracts;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;
        public CourseController(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<CourseReadDto>> GetAll()
        {
            var model = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<CourseReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult<CourseReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                return Ok(_mapper.Map<CourseReadDto>(model));
            }
            return NotFound();
        }

        [HttpPost("")]
        public ActionResult<CourseReadDto> Create(CourseCreateDto vm)
        {
            var model = _mapper.Map<Course>(vm);
            _repository.Create(model);
            var readDto = _mapper.Map<CourseReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CourseUpdateDto vm)
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
