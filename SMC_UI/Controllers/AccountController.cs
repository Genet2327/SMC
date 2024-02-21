using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMC_UI.Models;
using SMC_UI.Models.Account;
using SMC_UI.Models.Role;
using SMC_UI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SMC_UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind] Login model)
        {
            if (ModelState.IsValid)
            {
                AuthenticationModel user = await accountService.Login(model);
                if (user.Token != null)
                {
                    List<Claim> claims = new()
                    {
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.Sid, user.Token),
                        new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user))
                    };
                    claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r)));

                    ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties authProperties = new() { ExpiresUtc = DateTime.Now.AddMinutes(10), };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, user.Message);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind] Register model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountService.Register(model);
                if (result.Message == null) return RedirectToAction("Login");
                ModelState.AddModelError(string.Empty, result.Message);
            }
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View(new RoleCreateDto());
        }

        [HttpPost]
        public ActionResult CreateRole(RoleCreateDto vm)
        {
            _ = accountService.CreateRole(vm, User.UserToke());

            return RedirectToAction("Index");
        }
    }
}
