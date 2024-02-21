using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_UI.Models.Student;
using SMC_UI.Service;
using System.Collections.Generic;

namespace SMC_UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        private readonly IClassRoomService _ClassRoomService;
        private readonly IResultService _resultService;
        private readonly IAttendanceService _attendanceService;

        public StudentController(ILogger<HomeController> logger,
            IStudentService studentService,
            IClassRoomService ClassRoomService,
            IResultService resultService,
            IAttendanceService attendanceService
            )
        {
            _logger = logger;
            _studentService = studentService;
            _ClassRoomService = ClassRoomService;
            _resultService = resultService;
            _attendanceService = attendanceService;
        }
        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<StudentReadDto> students = _studentService.GetAll(User.UserToke()).Result;
            return View(students);
        }

        public ActionResult Views(int id)
        {
            return View(new StudentViewDto
            {
                StudentRead = _studentService.GetById(id, User.UserToke()).Result ?? new StudentReadDto(),
                ResultsRead = _resultService.GetByStudentId(id, User.UserToke()).Result,
                AttendancesRead = _attendanceService.GetByStudentId(id, User.UserToke()).Result
            } ?? new StudentViewDto());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentCreateDto { ClassRooms = _ClassRoomService.GetAll(User.UserToke()).Result });
        }

        [HttpPost]
        public ActionResult Create(StudentCreateDto vm)
        {
            if (ModelState.IsValid)
            {
                _ = _studentService.Create(vm, User.UserToke());
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            var students = _studentService.GetById(id, User.UserToke()).Result;

            return View(new StudentUpdateDto
            {
                FirstName = students.FirstName,
                LastName = students.LastName,
                MiddleName = students.MiddleName,
                MotherName = students.MotherName,
                Adress = students.Adress,
                Age = students.Age,
                ChristeningName = students.ChristeningName,
                GenderId = students.GenderId,
                OccupationType = students.OccupationType,
                Telephone = students.Telephone,
                ClassRoomId = students.ClassRoomId,
                GreadId = students.GreadId,
                ClassRooms = _ClassRoomService.GetAll(User.UserToke()).Result
            });
        }

        [HttpPost]
        public ActionResult Edit(StudentUpdateDto vm)
        {
            if (ModelState.IsValid)
            {
                _studentService.Update(vm, User.UserToke());
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public ActionResult Delete(int id)
        {
            _studentService.Delete(id, User.UserToke());
            return RedirectToAction("Index");
        }
    }
}
