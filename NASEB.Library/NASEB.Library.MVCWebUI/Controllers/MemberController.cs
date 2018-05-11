using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.MVCWebUI.Models;
using NASEB.Library.Services.Abstract;
using Newtonsoft.Json;
using static TRIDVerification.KPSPublicSoapClient;

namespace NASEB.Library.MVCWebUI.Controllers
{
    public class MemberController : Controller
    {
        IMemberService memberService;
        public MemberController(IMemberService member)
        {
            memberService = member;
        }
        public IActionResult Index()
        {
            return View(memberService.GetAll().ToList());
        }

        //GET:Add new member
        public IActionResult Add()
        {
            return View(new AddMemberModel());
        }

        //POST: Add new member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddMemberModel model)
        {
            if (ModelState.IsValid)
            {

                var cliemUserID = User.Claims.FirstOrDefault(a => a.Type.Equals("UserID"));
                var userID = int.Parse(cliemUserID.Value.ToString());
                var addedMember = new Member()
                {
                    CreatedDate = DateTime.Now,
                    isTRCitezen = model.isTRCitizen=="on",
                    isTRIDCitizenVerfied = true,
                    LastUpdatedDate = DateTime.Now,
                    TRIDNo = model.TRIDNo,
                    Name = model.Name.ToUpper(),
                    Surname = model.Surname.ToUpper(),
                    UserID=userID,
                    BirthDate =new DateTime(model.BirthYear,1,1),
                    TotalRentConut=model.MaxRentLimit,
                    EMail=model.EMail.ToLower(),
                    PhoneNumber=model.PhoneNumber,
                    isEMailVerified=true,
                    isPhoneNumberVerified=model.isPhonumberVerified=="on",
                    Address=model.Address.ToUpper(),
                    isAddressVerified=model.isAddressVerified=="on",
                    Status =model.isActive=="on"?MemberStatusType.Acitive:MemberStatusType.Suspanded,
                    RemainedRentConut =model.MaxRentLimit,
                    AwaableToRent=model.isAwaableToRent=="on"
                };

                var operationResult = await memberService.AddAsync(addedMember);
                if (operationResult.isSuccess)
                    return RedirectToAction("Index");
                foreach (var item in operationResult.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id=0)
        {
            if (id == 0)
                return Redirect("/");
            var member = await memberService.GetAsync(a => a.MemberID == id);
            if (member == null)
                return Redirect("/");
            var editmembermodel = new EditMemberModel()
            {
                MemberID=id,
                Address=member.Address,
                BirthYear=member.BirthDate.Year,
                EMail=member.EMail,
                MaxRentLimit=member.TotalRentConut,
                TRIDNo=member.TRIDNo,
                Name=member.Name,
                PhoneNumber=member.PhoneNumber,
                Surname=member.Surname               
            };
            return View(editmembermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditMemberModel model)
        {
            if (ModelState.IsValid)
            {
                var member = await memberService.GetAsync(a => a.MemberID == model.MemberID);
                if (member == null)
                    return View("Index");
                else
                {
                    member.Address = model.Address.ToUpper();
                    member.EMail = model.EMail.ToLower();
                    member.PhoneNumber = model.PhoneNumber;
                    member.TotalRentConut = model.MaxRentLimit;
                    var updateResult = await memberService.UpdateAsync(member);
                    if (updateResult.isSuccess)
                    {
                        return View("Index");
                    }
                    foreach (var item in updateResult.Errors)
                    {
                        ModelState.TryAddModelError("", item);
                    }
                }
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult Search(string id)
        {
            var model = new BaseOperationModel();
            List<BaseSelectModel> result = memberService.SearchForMembers(id).ToList();
            model.Message = result.Count().ToString() + " Eşleşen üye bulundu";
            if (result.Count()>0)
            {
                model.isSuccess = true;
                model.Data = result;
            }
      
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0)
        {
            var model = new BaseOperationModel();

            var result = await memberService.DeleteAsync(new Member() { MemberID = id });

            model.isSuccess = result.isSuccess;
            model.Message = string.Join(";", result.Errors);
            return Ok(model);
        }
    }
}