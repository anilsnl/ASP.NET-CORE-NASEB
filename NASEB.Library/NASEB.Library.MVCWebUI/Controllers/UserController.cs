using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Edm;
using Microsoft.EntityFrameworkCore;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.MVCWebUI.Models;
using NASEB.Library.Services.Abstract;

namespace NASEB.Library.MVCWebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAll().OrderBy(a => a.NameSurname).ToListAsync();
            return View(users);
        }

        //GET:add new user
        public IActionResult Add()
        {
            return View(new AddNewUserModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddNewUserModel model)
        {
            if (ModelState.IsValid)
            {
                var addedUser = new NASEB.Library.Entities.Concrete.User()
                {
                    CreatedDate = DateTime.Now,
                    EMail = model.EMail,
                    LastUpdatedDate = DateTime.Now,
                    NameSurname = model.NameSurname
                 };
                var serviceResult = await _userService.CreateUserAsync(addedUser, model.Password);
                if (serviceResult.isSuccess)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in serviceResult.Errors)
                {
                    ModelState.AddModelError("", item);
                }
             }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var resultModel=new BaseOperationModel();
            if (ModelState.IsValid)
            {
                var result =
                    await _userService.ChangePasswordAsync(User.Identity.Name, model.CurrentPassword,
                        model.NewPassword);
                if (result.isSuccess)
                {
                    resultModel.isSuccess = true;
                    resultModel.Message = "Parola başarıyla değiştirildi!";
                }
                else
                {
                    resultModel.isSuccess = false;
                    resultModel.Message = string.Join(";", result.Errors);
                }
            }
            else
            {
                resultModel.isSuccess = false;
                resultModel.Message = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
            }

            return Ok(resultModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetUserResetPasswordModel model,int id)
        {

            model.UserID = id;
            var result = new BaseOperationModel();
            if (ModelState.IsValid)
            {
                var serviceResult = await _userService.ResetPasswordAsync(model.UserID, model.NewPassword);
                result.isSuccess = serviceResult.isSuccess;
                result.Message = String.Join(";", serviceResult.Errors);
            }
            else
            {
                result.isSuccess = false;
                result.Message = string.Join(";", ModelState.Select(a => a.Value));
            }
            return Ok(result);
        }

        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");
            var user = await _userService.GetAsync(a => a.UserID == id);
            if (user == null)
                return RedirectToAction("Index");
            var editmodel = new EditUserModel()
            {
                EMail = user.EMail,
                NameSurname = user.NameSurname,
                UserID = user.UserID
            };
            return View(editmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserModel model,int id=0)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetAsync(a => a.UserID == id);
                if (user == null)
                    return Redirect("/User/");
                user.NameSurname = model.NameSurname;
                user.EMail = model.EMail;
                user.LastUpdatedDate = DateTime.Now;
                var result = await _userService.UpdateAsync(user);
                if (result.isSuccess)
                    return Redirect("/User/");
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View(model);
        }
    }
}