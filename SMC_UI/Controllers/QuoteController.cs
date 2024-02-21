using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_API.Dtos.Quote;
using SMC_UI.Service;
using System.Collections.Generic;

namespace SMC_UI.Controllers
{
    public class QuoteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuoteService _quoteService;

        public QuoteController(ILogger<HomeController> logger,
            IQuoteService quoteService)
        {
            _logger = logger;
            _quoteService = quoteService;
        }
        public IActionResult Index()

        {
            //IEnumerable<QuoteReadDto> model = _quoteService.GetAll(User.UserToke()).Result;
            IEnumerable<QuoteReadDto> model = _quoteService.GetAll(User.UserToke()).Result;

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuoteCreateDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            _quoteService.Create(vm, User.UserToke());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = _quoteService.GetById(id, User.UserToke()).Result;

            return View(new QuoteUpdateDto
            {
                Id = model.Id,
                Description = model.Description
            });
        }
        [HttpPost]
        public ActionResult Edit(QuoteUpdateDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            _quoteService.Update(vm, User.UserToke());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _quoteService.Delete(id, User.UserToke());
            return RedirectToAction("Index");
        }

    }
}
