using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NASEB.MVCWebUI.Models;
using NASEB.Services.Abstruck;

namespace NASEB.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        public AccountController(IUserService userSer)
        {
            _userService = userSer;
        }
        public IActionResult Index(string ReturnUrl)
        {
            ViewBag.url = ReturnUrl;
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string ReturnUrl = ViewBag.url;
                var result = _userService.VerifyForLogin(model.Username, model.Password);
                switch (result.Result)
                {
                    case Entities.ComplexType.LoginResults.InvalidUser:
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                        return View(model);
                    case Entities.ComplexType.LoginResults.isSuccess:
                        var user = _userService.Get(a => a.EMail.Equals(model.Username));
                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name,user.EMail),
                        new Claim("FullName",user.Name+" "+user.Surname)
                        
                        };
                        
                        //ClaimsIdentity
                        var cIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperty = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = model.SaveMe
                        };
                        await HttpContext.
                            SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(cIdentity), authProperty);
                        return Redirect(ReturnUrl ?? "/");
                       
                    case Entities.ComplexType.LoginResults.NotActiveAccount:
                        ModelState.AddModelError("", "Hesap aktif değil.");
                        return View(model);
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login");
        }
    }
}