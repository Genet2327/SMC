using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_UI.Models.Course;
using SMC_UI.Service;
using System.Collections.Generic;

namespace SMC_UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;   

        public CourseController(ILogger<HomeController> logger, 
            ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }
        public ActionResult Index()
        {
            IEnumerable<CourseReadDto> model = _courseService.GetAll(User.UserToke()).Result;
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
        public ActionResult Create(CourseCreateDto vm)
        {
            if (!ModelState.IsValid)  return View(vm);

            _courseService.Create(vm, User.UserToke());
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _courseService.GetById(id, User.UserToke()).Result;

            return View(new CourseUpdateDto
            {
                Id = model.Id,
                Name = model.Name
            });
        }

        [HttpPost]
        public ActionResult Edit(CourseUpdateDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            _courseService.Update(vm, User.UserToke());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _courseService.Delete(id, User.UserToke());
            return RedirectToAction("Index");
        }
    }
}
