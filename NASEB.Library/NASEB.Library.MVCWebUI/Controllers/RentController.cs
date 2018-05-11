using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.MVCWebUI.Models;
using NASEB.Library.Services.Abstract;

namespace NASEB.Library.MVCWebUI.Controllers
{
    public class RentController : Controller
    {
        IRentService rentService;
        public RentController(IRentService rent)
        {
            rentService = rent;
        }
        public async Task<IActionResult> Index()
        {
            var model = await rentService.GetRentOverview(a => a.isRentingCompleted == false || (DateTime.Now - a.ExpactedEndDate).TotalDays < 8).OrderByDescending(a => a.ExpactedEndDate).ToListAsync();
            return View(model);
        }

        //GET:nEW RENT
        public async Task<IActionResult> New()
        {
            return View(new AddNewRentModel());
        }

        //POST: NEW RENT
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> New(AddNewRentModel model)
        {
            if (ModelState.IsValid)
            {
                var rentStartDate = new DateTime(model.StartYear, model.StartMonth, model.StartDay);
                var rentEndDate = rentStartDate.AddDays(model.RentDayCount);

                var cliemUserID = User.Claims.FirstOrDefault(a => a.Type.Equals("UserID"));
                var userID = int.Parse(cliemUserID.Value.ToString());

                var rent = new RentHistory()
                {
                    BookID = model.BookID,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    isDelayed = false,
                    MemberID = model.MemberID,
                    RentDate = rentStartDate,
                    RentEndDate = rentEndDate,
                    DelayedDayCount = 0,
                    UserID = userID,
                    DelayFine =0,
                };

                var result = await rentService.AddAsync(rent);
                if (result.isSuccess)
                    return RedirectToAction("Index");
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Complete(int id=0)
        {
            var model = new BaseOperationModel();
            var result = await rentService.ComplateRentByIDAsync(id);
            model.isSuccess = result.isSuccess;
            model.Message = String.Join(";", result.Errors);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> ExpandDay(int id=0,int day=0 )
        {
            var model = new BaseOperationModel();
            var result = await rentService.ExpandRentingEndDate(id, day);
            model.isSuccess = result.isSuccess;
            model.Message = string.Join(";", result.Errors);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0)
        {
            var model = new BaseOperationModel();

            var result = await rentService.DeleteAsync(new RentHistory() { RentID = id });

            model.isSuccess = result.isSuccess;
            model.Message = string.Join(";", result.Errors);
            return Ok(model);
        }

        int currentYear = DateTime.Now.Year;
        public async Task<IActionResult> History(int id = 0)
        {
            if (id == 0)
                id = currentYear;
            return View(await rentService.GetRentHistories(a => a.RegistereedYear == id).OrderBy(a => a.MemberName).ToListAsync());
        }

        [HttpPost]
        public IActionResult GetHistory(int id)
        {
            return Redirect("/Rent/History/" + id);
        }
    }
}