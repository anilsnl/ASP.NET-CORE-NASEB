using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using NASEB.MVCWebUI.Models;
using NASEB.Services.Abstruck;

namespace NASEB.MVCWebUI.Controllers
{
    public class RentController : Controller
    {
        private IRentService _service;
        private IUserService _IuserService;
        private ICustomerService customer;
        private IBranchService branch;
        private ICompanyService company;
        private ICarService car;
        public RentController(IRentService service,ICustomerService _customer,IBranchService _branch,ICompanyService _company,ICarService _car,IUserService srvc)
        {
            _service = service;
            customer = _customer;
            branch = _branch;
            company = _company;
            car = _car;
            _IuserService = srvc;
        }
        public IActionResult Index()
        {
            return View(_service.GetRentInfos());
        }
        public IActionResult Add()
        {
            var a = _IuserService.Get(x => x.EMail.Equals(User.Identity.Name));
            ViewBag.user = a.UserID;
            ViewBag.customer = customer.GetAll();
            ViewBag.branch = branch.GetAll();
            ViewBag.car = car.GetAll();
            return View(company.GetAll());
        }
        [HttpPost]
        public IActionResult Add(RentCustomerBranchUserView Rtmdl)
        {
            var rent = new Rent();
            rent.CustomerID = Rtmdl.CustomerID;
            rent.DamagePrice = Rtmdl.DamagePrice;
            rent.DelayFine = Rtmdl.DelayFine;
            rent.RentBranchID = Rtmdl.BranchID;
            rent.RemaindDebt = Rtmdl.RemainDebt;
            rent.DeliveredBranchID = Rtmdl.BranchID;
            rent.TotalRentPrice = Rtmdl.TotalRentPrice;
            rent.UserID = Rtmdl.UserID;
            rent.CarID = Rtmdl.CarID;
            rent.RentStartDate = DateTime.Now;
            rent.RentEndDate = DateTime.Now.AddDays(Rtmdl.HowManyDays);
           
            _service.Add(rent);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var safak = _service.Get(x => x.RentID == id);
            return View(safak);

        }
        [HttpPost]
        public IActionResult Deletee(int id)
        {
            var baris = _service.Get(x => x.RentID == id);
            if (baris != null)
            {
                _service.Delete(baris);
            }


            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            ViewBag.rent = _service.Get(x => x.RentID == id);
            var a = _IuserService.Get(x => x.EMail.Equals(User.Identity.Name));
            ViewBag.user = a.UserID;
            ViewBag.customer = customer.GetAll();
            ViewBag.branch = branch.GetAll();
            ViewBag.car = car.GetAll();
            return View(company.GetAll());
        }
        [HttpPost]
        public IActionResult Edit(RentModel rml)
        {
            var rent = _service.Get(x => x.RentID == rml.RentID);
            rent.CompanyID = rml.CompanyID;
            rent.CustomerID = rml.CustomerID;
            rent.DamagePrice = rml.DamagePrice;
            rent.DelayFine = rml.DelayFine;
            rent.RentBranchID = rml.RentBranchID;
            rent.DeliveredBranchID = rml.BranchID;
            rent.TotalRentPrice = rml.TotalRentPrice;
            rent.UserID = rml.UserID;
            rent.CarID = rml.CarID;
            rent.RentStartDate = DateTime.UtcNow;
            rent.RentEndDate = DateTime.FromFileTime(11111995);
            _service.Update(rent);
            return RedirectToAction("Index");
        }
    }
}