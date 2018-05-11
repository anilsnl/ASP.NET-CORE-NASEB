using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NASEB.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.MVCWebUI.Models;
using NASEB.Library.Services.Abstract;

namespace NASEB.Library.MVCWebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IMemberService _memberService;
    
        public AccountController(IUserService userSer,IMemberService memberService)
        {
            _userService = userSer;
            _memberService = memberService;
        }
        public IActionResult Index(string ReturnUrl)
        {
            ViewBag.url = ReturnUrl;
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string ReturnUrl = ViewBag.url;
                var result = await _userService.CheckForLoginAsync(new User(){EMail = model.Username}, model.Password);
                switch (result.Result)
                {
                    case LoginResults.InvalidUser:
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                        return View(model);
                    case LoginResults.isSuccess:
                        var user = _userService.Get(a => a.EMail.Equals(model.Username));
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.EMail),
                            new Claim("FullName",user.NameSurname),
                            new Claim("UserID",user.UserID.ToString()),
                            new Claim(ClaimTypes.Role,"user"),
                            new Claim(ClaimTypes.Role, "admin")
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

                    case LoginResults.NotActiveAccount:
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

        public IActionResult ResetPassword()
        {
            return View(new ResetPasswordModel());
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.isComplated = true;
            }

            return View(model);
        }

        public IActionResult LoginMember()
        {
            return View(new MemberLoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginMember(MemberLoginModel model)
        {
            if (ModelState.IsValid)
            {
                string ReturnUrl = ViewBag.url;
                var result = await _memberService.CheckForLoginAsync(model.Name, model.Surname, model.BirthYear, model.TRIDNo, model.Citizenship == "1");
                switch (result.Result)
                {
                    case LoginResults.InvalidUser:
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                        return View(model);
                    case LoginResults.isSuccess:
                        var user = await _memberService.GetAsync(a=>a.TRIDNo==model.TRIDNo);
                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name,user.EMail),
                        new Claim("FullName",user.Name+" "+user.Surname),
                        new Claim("UserID",user.MemberID.ToString()),
                        new Claim(ClaimTypes.Role,"member")
                        };

                        //ClaimsIdentity
                        var cIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperty = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = model.SaveMe=="on"
                        };
                        await HttpContext.
                            SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(cIdentity), authProperty);
                        return Redirect(ReturnUrl ?? "/");

                    case LoginResults.NotActiveAccount:
                        ModelState.AddModelError("", "Hesap aktif değil.");
                        return View(model);
                }
            }
            return View(model);
        }
    }
}