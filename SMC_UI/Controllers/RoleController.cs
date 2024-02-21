using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMC_UI.Models.Account;
using SMC_UI.Models.Role;
using SMC_UI.Service;
using System.Collections.Generic;

namespace SMC_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        public ActionResult Index()
        {
            IEnumerable<RoleReadDto> model = roleService.GetAll(User.UserToke()).Result;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoleCreateDto vm)
        {
            if (!ModelState.IsValid) return View(vm);

            roleService.Create(vm, User.UserToke());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(AddRoleModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            roleService.AddRole(vm, User.UserToke());
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var model = roleService.GetById(id, User.UserToke()).Result;

            return View(new RoleUpdateDto
            {
                Id = model.Id,
                Name = model.Name
            });
        }
        [HttpPost]
        public ActionResult Edit(RoleUpdateDto vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            roleService.Update(vm, User.UserToke());
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            roleService.Delete(id, User.UserToke());
            return RedirectToAction("Index");
        }
    }
}
