using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMC_API.Dtos.Exam;
using SMC_Contracts;
using SMC_Entities.Models;
using System.Collections.Generic;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;
        public ExamController(IExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<ExamReadDto>> GetAll()
        {
            var model = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<ExamReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult<ExamReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                return Ok(_mapper.Map<ExamReadDto>(model));
            }
            return NotFound();
        }

        [HttpPost("")]
        public ActionResult<ExamReadDto> Create(ExamCreateDto vm)
        {
            var model = _mapper.Map<Exam>(vm);
            _repository.Create(model);
            var readDto = _mapper.Map<ExamReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ExamUpdateDto vm)
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
