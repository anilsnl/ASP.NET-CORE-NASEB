using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NASEB.Entities.Concrete;
using NASEB.Helper.Security;
using NASEB.MVCWebUI.Models;
using NASEB.Services.Abstruck;

namespace NASEB.MVCWebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserService service;
        private IBranchService branch;
        public UserController(IUserService _service, IBranchService _branch)
        {
            service = _service;
            branch = _branch;
        }
        public IActionResult Index()
        {
            return View(service.UserBranchName());
        }
        public IActionResult Add()
        {
            return View(branch.GetAll());
        }
        [HttpPost]
        public IActionResult Add(UserModel crmdl)
        {
            if (ModelState.IsValid)
            {
                var user = new NASEBUser();
                user.Name = crmdl.Name;
                user.PasswordHash = Hasher.HashPassword(crmdl.Parola);
                user.Surname = crmdl.Surname;
                user.EMail = crmdl.Email;
                user.BirthDate = new DateTime(crmdl.Year,crmdl.Month,crmdl.Day);
                user.RegisterDate = DateTime.Now;
                user.PhoneNumber = crmdl.PhoneNumber;
                user.Address = crmdl.Adress;
                user.BranchID = crmdl.BranchID;
                service.Add(user);
                return RedirectToAction("Index");
            
            }
            else
            {
                return View();
            }
           
        }
        public IActionResult ChangePassword()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel changepassword)
        {
            var hashlipassword = Hasher.HashPassword(changepassword.EskiSifre);
            var hashliyenipassword = Hasher.HashPassword(changepassword.YeniSifre);
            var user = service.Get(x => x.EMail == changepassword.Email && x.PasswordHash == hashlipassword);

            if (user != null)
            {
                user.PasswordHash = hashliyenipassword;
            }
            service.Update(user);
            
            return Redirect("/Account/LogOut");
        }
        public IActionResult Delete(int id)
        {
            var safak = service.Get(x => x.UserID == id);
            return View(safak);

        }
        [HttpPost]
        public IActionResult Deletee(int id)
        {
            var baris = service.Get(x => x.UserID == id);
            if (baris != null)
            {
                service.Delete(baris);
            }


            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            ViewBag.user = service.Get(x => x.UserID == id);
            return View(branch.GetAll());
        }
        [HttpPost]
        public IActionResult Edit(UserModel usrmdl)
        {
            if (ModelState.IsValid)
            {
            var user = service.Get(x => x.UserID == usrmdl.UserID);
            user.Name = usrmdl.Name;
                if (usrmdl.Parola != null)
                 {
                user.PasswordHash = Hasher.HashPassword(usrmdl.Parola);
                }
            user.Surname = usrmdl.Surname;
            user.EMail = usrmdl.Email;
            user.PhoneNumber = usrmdl.PhoneNumber;
            user.Address = usrmdl.Adress;
            user.BranchID = usrmdl.BranchID;
            service.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(usrmdl);
            }
        }
    }
}