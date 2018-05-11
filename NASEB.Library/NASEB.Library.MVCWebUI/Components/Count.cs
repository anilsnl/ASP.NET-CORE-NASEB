using Microsoft.AspNetCore.Mvc;
using NASEB.Library.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.Library.MVCWebUI.Components
{
    public class Count:ViewComponent
    {
        IMemberService memberService;
        IBookService bookService;
        IRentService rentService;
        IUserService userService;
        public Count(IBookService book, IRentService rent, IMemberService member,IUserService user)
        {
            rentService = rent;
            bookService = book;
            memberService = member;
            userService = user;
        }

        public string Invoke(string firstLater)
        {
            switch (firstLater)
            {
                case "m":
                    return memberService.Count(null).ToString();
                case "b":
                    return bookService.Count(null).ToString();
                case "r":
                    return rentService.Count(a=>a.isRentingCompleted==false).ToString();
                case "u":
                    return userService.Count(null).ToString();
                default:
                    return "0";
            }
        }
    }
}
