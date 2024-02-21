using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_UI.Models.Attendance;
using SMC_UI.Service;
using System.Collections.Generic;

namespace SMC_UI.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAttendanceService _attendaceService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public AttendanceController(ILogger<HomeController> logger,
             IAttendanceService attendanceService,
             ICourseService courseService,
             IStudentService studentService)
        {
            _logger = logger;
            _attendaceService = attendanceService;
            _courseService = courseService;
            _studentService = studentService;

        }
        public ActionResult Index()
        {
            IEnumerable<AttendanceReadDto> model = _attendaceService.GetAll(User.UserToke()).Result;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var vm = new AttendanceMultipleStudentCreateDto
            {
                Courses = _courseService.GetAll(User.UserToke()).Result,
                Students = _studentService.GetAll(User.UserToke()).Result
            };
            return View(vm);
        }

        [HttpPost]

        public ActionResult Create(AttendanceMultipleStudentCreateDto model)
        {
            if (!ModelState.IsValid) return View(model);

            foreach (var studentId in model.StudentId)
            {
                _ = _attendaceService.Create(new AttendanceCreateDto
                {
                    CourseId = model.CourseId,
                    StudentId = studentId,
                    Status = model.Status,
                    Date =  model.Date
                }, User.UserToke());
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _attendaceService.GetById(id, User.UserToke()).Result;

            return View(new AttendanceUpdateDto
            {
                Id = model.Id,
                Status = model.Status,
                Date = model.Date,
                StudentId = model.StudentId,
                CourseId = model.CourseId,
                Courses = _courseService.GetAll(User.UserToke()).Result,
                Students = _studentService.GetAll(User.UserToke()).Result
            });
        }

        [HttpPost]
        public ActionResult Edit(AttendanceUpdateDto model)
        {
            _attendaceService.Update(model, User.UserToke());
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _attendaceService.Delete(id, User.UserToke());
            return RedirectToAction("Index");
        }
    }
}
