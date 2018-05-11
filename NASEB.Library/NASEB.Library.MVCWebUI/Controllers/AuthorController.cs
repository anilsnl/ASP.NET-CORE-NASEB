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
    public class AuthorController : Controller
    {
        private IAuthorService AuthorService;

        public AuthorController(IAuthorService authorService)
        {
            AuthorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await AuthorService.GetAll().OrderBy(x=>x.NameSurname).ToListAsync());
        }



        //for adding author
        [HttpPost]
        public async Task<JsonResult> Add(string id)
        {
            if (id!=null&&id.Length>5)
            {
                var result = await AuthorService.AddAsync(new Author() { NameSurname = id.ToUpper()});
                if (result.isSuccess)
                {
                    return Json(new BaseOperationModel()
                    {
                        isSuccess = true,
                        Message ="Yazar başarıyla eklendi!"
                    });
                }
                else
                {
                    return Json(new BaseOperationModel()
                    {
                        isSuccess = false,
                        Message = string.Join(";",result.Errors)
                    });
                }
            }
            else
            {
                return Json(new BaseOperationModel()
                {
                    isSuccess = false,
                    Message = "Girdiğiniz değerleri kontrol edin!"
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0)
        {
            var model = new BaseOperationModel();

            var result = await AuthorService.DeleteAsync(new Author() { AuthorID = id });

            model.isSuccess = result.isSuccess;
            model.Message = string.Join(";", result.Errors);
            return Ok(model);
        }
    }
}