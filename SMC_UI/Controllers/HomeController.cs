using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMC_API.Dtos.Quote;
using SMC_UI.Models;
using SMC_UI.Models.Home;
using SMC_UI.Service;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SMC_UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        private readonly IClassRoomService _ClassRoomService;
        private readonly IQuoteService quoteService;

        public HomeController(ILogger<HomeController> logger,
             IStudentService studentService,
            IClassRoomService ClassRoomService, IQuoteService quoteService)
        {
            _studentService = studentService;
            _ClassRoomService = ClassRoomService;
            this.quoteService = quoteService;
            _logger = logger;
        }

        public ActionResult Index()
        {
            IEnumerable<QuoteReadDto> model = quoteService.GetAll(User.UserToke()).Result;

            return View(model);
            //return View(new HomeVm
            //{
            //    StudentCount = _studentService.GetAll(User.UserToke()).Result.Count(),
            //    CurrentClassRoom = _ClassRoomService.GetAll(User.UserToke()).Result.FirstOrDefault(i => i.IsActive).Name
            //});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
