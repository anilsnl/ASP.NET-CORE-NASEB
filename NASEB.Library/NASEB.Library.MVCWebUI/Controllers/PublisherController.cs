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
   
    public class PublisherController : Controller
    {
        private IPublisherService PublisherService;

        public PublisherController(IPublisherService publisherService)
        {
            PublisherService = publisherService;
        }
        public async Task<IActionResult> Index()
        {
            var publishers = await PublisherService.GetAll().OrderBy(a => a.PublisherName).ToListAsync();
            return View(publishers);
        }


        public async Task<JsonResult> Add(string id)
        {
            if (id!=null&&id.Length>5)
            {
                var publisher = new Publisher()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    PublisherName = id.ToUpper()
                };
                var result = await PublisherService.AddAsync(publisher);
                var model=new BaseOperationModel()
                {
                    isSuccess = result.isSuccess,
                    Message = string.Join(";",result.Errors)
                };
                return Json(model);
            }
            else
            {
                var model = new BaseOperationModel();
                model.isSuccess = false;
                model.Message = "Yayınevi alanı en az 5 karaterden oluşmalıdır";
                return Json(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id = 0)
        {
            var model = new BaseOperationModel();

            var result = await PublisherService.DeleteAsync(new Publisher() { PublisherID = id });

            model.isSuccess = result.isSuccess;
            model.Message = string.Join(";", result.Errors);
            return Ok(model);
        }
    }
}