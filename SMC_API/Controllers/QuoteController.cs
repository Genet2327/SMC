using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMC_API.Dtos.Quote;
using SMC_API.Dtos.Result;
using SMC_Contracts;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository _repository;
        private readonly IMapper _mapper;
        public QuoteController(IQuoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<QuoteReadDto>> Getall([FromQuery] QueryStringParameters parameters)
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
            return Ok(_mapper.Map<IEnumerable<QuoteReadDto>>(model));
        }
        [HttpGet("{id}")]
        public ActionResult<QuoteReadDto> GetById(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                return Ok(_mapper.Map<QuoteReadDto>(model));
            }
            return NotFound();
        }
        [HttpPost("")]
        public ActionResult<QuoteReadDto> Create(QuoteCreateDto vm)
        {
            var model = _mapper.Map<Quote>(vm);
            _repository.Create(model);
            var readDto = _mapper.Map<QuoteReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, QuoteUpdateDto rtt)
        {
            var model = _repository.GetById(id);
            if (model == null)
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
            if (model == null)
            {
                return NotFound();
            }
            _repository.Delete(model);
            return NoContent();
        }
    }
}
