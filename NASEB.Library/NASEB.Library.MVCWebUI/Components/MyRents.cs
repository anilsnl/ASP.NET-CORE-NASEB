using Microsoft.AspNetCore.Mvc;
using NASEB.Library.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.Library.MVCWebUI.Components
{
    public class MyRents : ViewComponent
    {
        IRentService rentService;
        IMemberService memberService;
        public MyRents(IRentService rent,IMemberService user)
        {
            rentService = rent;
            memberService = user;
        }
        public IViewComponentResult Invoke()
        {
            var member =  memberService.Get(a => a.EMail.Equals(User.Identity.Name));
            int id = member.MemberID;
            return View(rentService.GetRentOverview(a => a.MemberID == id).ToList());
        }
    }
}
