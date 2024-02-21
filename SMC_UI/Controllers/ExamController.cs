using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_UI.Models.Exam;
using SMC_UI.Service;
using System.Collections.Generic;

namespace SMC_UI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExamService _ExamService;   

        public ExamController(ILogger<HomeController> logger, 
            IExamService ExamService)
        {
            _logger = logger;
            _ExamService = ExamService;
        }
        public ActionResult Index()
        {
            IEnumerable<ExamReadDto> model = _ExamService.GetAll(User.UserToke()).Result;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExamCreateDto vm)
        {
            if (!ModelState.IsValid)  return View(vm);

            _ExamService.Create(vm, User.UserToke());
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _ExamService.GetById(id, User.UserToke()).Result;

            return View(new ExamUpdateDto
            {
                Id = model.Id,
                Name = model.Name
            });
        }

        [HttpPost]
        public ActionResult Edit(ExamUpdateDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            _ExamService.Update(vm, User.UserToke());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _ExamService.Delete(id, User.UserToke());
            return RedirectToAction("Index");
        }
    }
}
