using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMC_API.Dtos.Result;
using SMC_Contracts;
using SMC_Entities.Dtos.Result;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;
using System.Linq;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : Controller
    {
        private readonly IResultRepository _repository;
        private readonly IMapper _mapper;
        public ResultController(IResultRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ResultReadDto>> Getall([FromQuery] QueryStringParameters parameters)
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
            return Ok(_mapper.Map<IEnumerable<ResultReadDto>>(model));
        }

        [HttpGet("{id}")]
        public ActionResult <ResultReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if(model!=null)
            {
                return Ok(_mapper.Map<ResultReadDto>(model));
            }
            return NotFound();
        }

        [HttpGet("GetByStudentId/{id}")]
        public ActionResult<IEnumerable<ResultGroupByStudentIdVm>> GetByStudentId(int id)
        {
            var model = _repository.GetByStudentId(id);
            if (model != null)
            {
                return Ok(model);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <ResultReadDto> Create(ResultCreateDto ret)
        {
            var model = _mapper.Map<Result>(ret);
            _repository.Create(model);
            var readdto = _mapper.Map<ResultReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readdto.Id }, readdto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ResultUpdateDto rtt)
        {
            var model = _repository.GetById(id);
            if(model==null)
            {
                return NotFound();
            }
            _mapper.Map(rtt, model);
            _repository.Update(model);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _repository.GetById(id);
            if(model==null)
            {
                return NotFound();
            }
            _repository.Delete(model);
            return NoContent();
        }        
    }
}
