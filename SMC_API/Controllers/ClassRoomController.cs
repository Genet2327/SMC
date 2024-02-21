using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMC_API.Dtos.ClassRoom;
using SMC_API.Dtos.Student;
using SMC_Contracts;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;
using System.Linq;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomRepository _repository;
        private readonly IMapper _mapper;
        public ClassRoomController(IClassRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<ClassRoomReadDto>> GetAll()
        {
            var model = _repository.GetAll().ToList();       
            return Ok(_mapper.Map<IEnumerable<ClassRoomReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult<ClassRoomReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                return Ok(_mapper.Map<ClassRoomReadDto>(model));
            }
            return NotFound();
        }

        [HttpGet("AllStudent/{id}")]
        public ActionResult<IEnumerable<StudentRedByClassRoomNumberDto>> GetAllStudentByClassRoomId(int id)
        {
            var model = _repository.GetAllStudentByClassRoomId(id);
            if (model != null)
            {
                return Ok(_mapper.Map<IEnumerable<StudentRedByClassRoomNumberDto>>(model));
            }
            return NotFound();
        }

        [HttpPost("")]
        public ActionResult<ClassRoomReadDto> Create(ClassRoomCreateDto vm)
        {
            var model = _mapper.Map<ClassRoom>(vm);
            _repository.Create(model);
            var readDto = _mapper.Map<ClassRoomReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ClassRoomUpdateDto vm)
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
