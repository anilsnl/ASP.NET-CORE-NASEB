using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NASEB.Entities.Concrete;
using NASEB.MVCWebUI.Models;
using NASEB.Services.Abstruck;
using ServiceReference1;

namespace NASEB.MVCWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService customerService;
        private IUserService userService;
        public CustomerController(ICustomerService _cst,IUserService Usr)
        {
            customerService = _cst;
            userService = Usr;
        }
        public IActionResult Index()
        {
            return View(customerService.GetAll());
        }
        public IActionResult Add()
        {
            var a = userService.Get(x => x.EMail.Equals(User.Identity.Name));
            ViewBag.user = a.UserID;
            return View(new CustomerModel() { UserID =a.UserID});
        }
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CustomerModel crmdl)
        {
            var customer = new Customer();
            customer.Name = crmdl.CustomerName;
            customer.Adress = crmdl.Adress;
            customer.PhoneNumber = crmdl.PhoneNumber;
            customer.Surname = crmdl.CustomerSurname;
            customer.TRIDNo = crmdl.TRIDNO;
            customer.PasportNumber = crmdl.PasaportNumber;
            customer.UserID = crmdl.UserID;
            customer.BirthDate = crmdl.BirthDate;
            customer.RegisterDate = DateTime.Now;
            customer.isCorporate = customer.isTRIDVerified = false;
            customer.isTRCitizen = true;
         

            var operationresult = await customerService.AddAsync(customer);
            if (operationresult)
            {
                return RedirectToAction("Index");
            }
            return  View(crmdl);
        }
        public IActionResult Delete(int id)
        {
            var safak = customerService.Get(x => x.CustomerID == id);
            return View(safak);

        }
        [HttpPost]
        public IActionResult Deletee(int id)
        {
            var baris = customerService.Get(x => x.CustomerID == id);
            if (baris != null)
            {
                customerService.Delete(baris);
            }
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var a = userService.Get(x => x.EMail.Equals(User.Identity.Name));
            ViewBag.user = a.UserID;
            return View(customerService.Get(x=>x.CustomerID==id));
        }
        [HttpPost]
        public IActionResult Edit(CustomerModel cml)
        {
            var customer = customerService.Get(x => x.CustomerID == cml.CustomerID);
            customer.Name = cml.CustomerName;
            customer.Adress = cml.Adress;
            customer.PhoneNumber = cml.PhoneNumber;
            customer.Surname = cml.CustomerSurname;
            customer.TRIDNo = cml.TRIDNO;
            customer.PasportNumber = cml.PasaportNumber;
            customer.UserID = cml.UserID;
            customer.BirthDate = cml.BirthDate;
            customerService.Update(customer);
            return RedirectToAction("Index");
        }
    }
}