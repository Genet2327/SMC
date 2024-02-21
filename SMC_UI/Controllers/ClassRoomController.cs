using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_UI.Models.ClassRoom;
using SMC_UI.Models.Student;
using SMC_UI.Service;
using System.Linq;
using System.Text;

namespace SMC_UI.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClassRoomService classRoomService;
        private readonly IStudentService studentService;
        private readonly ISectionService sectionService;
        private readonly IAttendanceService attendanceService;
        private readonly IResultService resultService;

        public ClassRoomController(ILogger<HomeController> logger,
            IClassRoomService ClassRoomService,
            IStudentService studentService,
            ISectionService sectionService,
            IAttendanceService attendanceService,
            IResultService resultService)
        {
            _logger = logger;
            this.classRoomService = ClassRoomService;
            this.studentService = studentService;
            this.sectionService = sectionService;
            this.attendanceService = attendanceService;
            this.resultService = resultService;
        }

        public ActionResult Index()
        {
            var model = classRoomService.GetAll(User.UserToke()).Result;

            //var classNameGroup = model.GroupBy(l => new { l.Grade })
            //   .Select(g => new ClassRoomReadDto { 
            //       Grade = g.Key.Grade, 
            //       Section = string.Join(",", g.Select(i => i.Section)) 
            //   });

            return View(model);
        }

        public ActionResult ListOfAllClasses()
        {
            return View(classRoomService.GetAll(User.UserToke()).Result);
        }

        public ActionResult Views(int id)
        {
            return View(new StudentRedByClassRoomNumberVm
            {
                ClassRoom = classRoomService.GetById(id, User.UserToke()).Result,
                Data = classRoomService.GetAllStudentById(id, User.UserToke()).Result
            });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ClassRoomCreateDto { Sections = sectionService.GetAll(User.UserToke()).Result });
        }

        [HttpPost]
        public ActionResult Create(ClassRoomCreateDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            classRoomService.Create(vm, User.UserToke());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = classRoomService.GetById(id, User.UserToke()).Result;

            return View(new ClassRoomUpdateDto
            {
                Id = id,
                Name = model.Name,
                IsActive = model.IsActive,
                SectionId = model.SectionId,
                Sections = sectionService.GetAll(User.UserToke()).Result
            });
        }

        [HttpPost]
        public ActionResult Edit(ClassRoomUpdateDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            classRoomService.Update(vm, User.UserToke());
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            classRoomService.Delete(id, User.UserToke());
            return RedirectToAction("Index");
        }

        public ActionResult Certificate(int id)
        {
            return View("Certificate", new CertificateModel
            {
                Data = classRoomService.GetAllStudentById(id, User.UserToke()).Result.FirstOrDefault(s => s.StudentId == id),
                Student = studentService.GetById(id, User.UserToke()).Result
            });
        }

        public ActionResult Transcript(int id)
        {
            return View(new StudentViewDto
            {
                StudentRead = studentService.GetById(id, User.UserToke()).Result ?? new StudentReadDto(),
                ResultsRead = resultService.GetByStudentId(id, User.UserToke()).Result,
                AttendancesRead = attendanceService.GetByStudentId(id, User.UserToke()).Result
            } ?? new StudentViewDto());
        }

        public IActionResult GenerateReportCsv(int id)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Full Name,Total Score, Christening Name");
            foreach (var data in classRoomService.GetAllStudentById(id, User.UserToke()).Result)
            {
                builder.AppendLine($"{data.FullName},{data.TotalScore}, {data.ChristeningName}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "SMC_GenerateReportCsv.csv");
        }

        //public ActionResult GetPdf(string filename)
        //{
        //    using (WebClient client = new WebClient())
        //    {

        //        // Download data.
        //        byte[] arr = client.DownloadData("http://url-to-your-pdf-file.com/file1");

        //        File.WriteAllBytes(path_to_your_app_data_folder, arr)

        //   }
        //    return File(filename, "application/pdf", Server.UrlEncode(filename));
        //}
    }
}
