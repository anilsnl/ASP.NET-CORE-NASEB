using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NASEB.Entities.Concrete;
using NASEB.MVCWebUI.Models;
using NASEB.Services.Abstruck;

namespace NASEB.MVCWebUI.Controllers
{

    public class CarController : Controller
    {
        private ICarService _Icarservice;
        private IBranchService _BranchService;
        private IUserService _IuserService;

        public CarController(ICarService Icarservice,IBranchService brnc,IUserService usersrvc)
        {
            _Icarservice = Icarservice;
            _BranchService = brnc;
            _IuserService = usersrvc;
        }

        public IActionResult Index()
        {
            return View(_Icarservice.GetBranchOfCar());
        }
        public IActionResult Add()
        {
            var a = _IuserService.Get(x => x.EMail.Equals(User.Identity.Name));
            ViewBag.user = a.UserID;
            return View(_BranchService.GetAll());
        } 
            [HttpPost]
        public IActionResult Add(CarModel crmdl)
        {
      
            
            var car = new Car();
            car.CarName = crmdl.CarName;
            car.Detail = crmdl.Details;
            car.Plate = crmdl.Plate;
            car.Status = crmdl.Status;
            car.LicenseInfo = crmdl.LicenseInfo;
            car.ExistingBranchID = crmdl.ExistingBranchID;
            car.RegisterDate = DateTime.Now;
            car.UserID = crmdl.UserID;


            _Icarservice.Add(car);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var safak =_Icarservice.Get(x => x.CarID == id);
            return View(safak);
          
        }
        [HttpPost]
        public IActionResult Deletee(int id)
        {
            var baris = _Icarservice.Get(x => x.CarID == id);
            if (baris != null)
            {
                _Icarservice.Delete(baris);
            }


            return RedirectToAction("Index");
        
        }
        public IActionResult Edit(int id)
        {
            var a = _IuserService.Get(x => x.EMail.Equals(User.Identity.Name));
            ViewBag.user = a.UserID;
            ViewBag.car = _Icarservice.Get(x => x.CarID == id);
            return View(_BranchService.GetAll());
        }
        [HttpPost]
        public IActionResult Edit(CarModel crmdl)
        {
            var a = _Icarservice.Get(x => x.CarID == crmdl.CarID);
            a.CarName = crmdl.CarName;
            a.Detail = crmdl.Details;
            a.Plate = crmdl.Plate;
            a.Status = crmdl.Status;
            a.LicenseInfo = crmdl.LicenseInfo;
            a.ExistingBranchID = crmdl.ExistingBranchID;
            a.UserID = crmdl.UserID;

            _Icarservice.Update(a);
            
            return RedirectToAction("Index");
        }

    }
}