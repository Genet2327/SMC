using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMC_API.Dtos.Attendance;
using SMC_Contracts;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _repository;
        private readonly IMapper _mapper;
        public AttendanceController(IAttendanceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttendanceReadDto>> Getall([FromQuery] QueryStringParameters parameters)
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
            return Ok(_mapper.Map<IEnumerable<AttendanceReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult<AttendanceReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                return Ok(_mapper.Map<AttendanceReadDto>(model));
            }
            return NotFound();
        }

        [HttpGet("GetByStudentId/{id}")]
        public ActionResult<IEnumerable<AttendanceReadDto>> GetByStudentId(int id)
        {
            var model = _repository.GetByStudentId(id);
            if (model != null)
            {
                return Ok(_mapper.Map<IEnumerable<AttendanceReadDto>>(model));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AttendanceReadDto> Create(AttendanceCreateDto att)
        {
            var model = _mapper.Map<Attendance>(att);
            _repository.Create(model);
            var readdto = _mapper.Map<AttendanceReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readdto.Id }, readdto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, AttendanceUpdateDto att)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            _mapper.Map(att, model);
            _repository.Update(model);
            return NotFound();
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
