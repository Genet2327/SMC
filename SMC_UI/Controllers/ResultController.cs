using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_UI.Models.Result;
using SMC_UI.Models.Student;
using SMC_UI.Service;
using System.Collections.Generic;
using System.Linq;

namespace SMC_UI.Controllers
{
    public class ResultController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IResultService resultservice;
        private readonly IStudentService studentService;
        private readonly ICourseService courseService;
        private readonly IExamService examService;
        private readonly IClassRoomService classRoomService;

        public ResultController(ILogger<HomeController> logger,
            IResultService resultService,
            IStudentService studentService,
            ICourseService courseService,
            IExamService examService,
            IClassRoomService classRoomService)
        {
            _logger = logger;
            this.resultservice = resultService;
            this.studentService = studentService;
            this.courseService = courseService;
            this.examService = examService;
            this.classRoomService = classRoomService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ResulReadDto> model = resultservice.GetAll(User.UserToke()).Result;

            return View(model);
        }

        public ActionResult Search(SearchCreateVm search)
        {
            search.ClassRoom = classRoomService.GetAll(User.UserToke()).Result;
            search.Courses = courseService.GetAll(User.UserToke()).Result;
            search.Exams = examService.GetAll(User.UserToke()).Result;
            search.Students = new List<StudentReadDto>();
            return View(search); 
        }
        public ActionResult GetDetails(SearchCreateVm vm)
        {
            vm.Students = studentService.GetAll(User.UserToke()).Result.Where(c => c.ClassRoomId == vm.ClassRoomId);
            foreach (var item in vm.Students)
            {
                item.Resuls = resultservice.GetAll(User.UserToke()).Result.Where(s => s.StudentId == item.Id);
            }
            return View("GetDetails", vm);
        }

        [HttpGet]
        public ActionResult Create(int studentId, int courseId, int examId)
        {
            return PartialView("Create", new ResultCreateDto
            {
                CourseId = courseId,
                StudentId = studentId,
                ExamId = examId,
                Courses = courseService.GetAll(User.UserToke()).Result,
                Students = studentService.GetAll(User.UserToke()).Result,
                Exams = examService.GetAll(User.UserToke()).Result
            });
        }


        public ActionResult Create(ResultCreateDto model)
        {
            if (!ModelState.IsValid) return View(model);

            resultservice.Create(model, User.UserToke());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = resultservice.GetById(id, User.UserToke()).Result;

            return PartialView("Edit", new ResultUpdateDto
            {
                Id = model.Id,
                CourseId = model.CourseId,
                StudentId = model.StudentId,
                ExamId = model.ExamId,
                Marks = model.Marks,
                Courses = courseService.GetAll(User.UserToke()).Result,
                Students = studentService.GetAll(User.UserToke()).Result,
                Exams = examService.GetAll(User.UserToke()).Result
            });
        }

        [HttpPost]
        public ActionResult Edit(ResultUpdateDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            resultservice.Update(model, User.UserToke());
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            resultservice.Delete(id, User.UserToke());
            return Json(new { status = "true", msg = "Successfully deleted" });
        }
    }
}
