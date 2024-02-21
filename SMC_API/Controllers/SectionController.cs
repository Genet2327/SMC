using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMC_API.Dtos.Section;
using SMC_Contracts;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _repository;
        private readonly IMapper _mapper;

        public SectionController(ISectionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<SectionReadDto>> GetAll([FromQuery] QueryStringParameters parameters)
        {
            var model = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<SectionReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult<SectionReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                return Ok(_mapper.Map<SectionReadDto>(model));
            }
            return NotFound();
        }

        [HttpPost("")]
        public ActionResult<SectionReadDto> Create(SectionCreateDto vm)
        {
            var model = _mapper.Map<Section>(vm);
            _repository.Create(model);
            var readDto = _mapper.Map<SectionReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, SectionUpdateDto vm)
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
