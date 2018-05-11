using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.MVCWebUI.Models;
using NASEB.Library.Services.Abstract;

namespace NASEB.Library.MVCWebUI.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        IAuthorService authorService;
        IPublisherService publisherService;
        IBookTypeService bookTypeService;
        public BookController(IBookService _bookService, IAuthorService _authorService, IPublisherService _publisherService,IBookTypeService _bookTypeService)
        {
            bookService = _bookService;
            authorService = _authorService;
            publisherService = _publisherService;
            bookTypeService = _bookTypeService;
        }


        public async Task<IActionResult> Index(int id=0,int pid=0)
        {
            if (id != 0)
            {
                var author = await authorService.GetAsync(a => a.AuthorID == id);
                if (author!=null)
                {
                    ViewData["XTitle"] = author.NameSurname + " Tarafından yazılan kitaplar";
                    return View(await bookService.GetBasicBookListByAuthorID(id, null).OrderBy(a => a.BookName).ToListAsync());
                }
                
            }
            if (pid!=0)
            {
                var publisher = await publisherService.GetAsync(a => a.PublisherID == pid);
                if (publisher != null)
                {
                    ViewData["XTitle"] = publisher.PublisherName + " Tarafından yayınlanan kitaplar";
                    return View(await bookService.GetBasicBookList().Where(a=>a.PublisherID==pid).OrderBy(a=>a.BookName).ToListAsync());
                }
            }
            return View(await bookService.GetBasicBookList().OrderBy(a=>a.BookName).ToListAsync());
        }

        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel();
            var authorList = await authorService.GetAll().OrderBy(a => a.NameSurname).ToListAsync();
            foreach (var author in authorList)
            {
                model.Authors.Add(new BaseSelectModel(author.AuthorID.ToString(),author.NameSurname));
            }

            var bookTypeList = await bookTypeService.GetAll().OrderBy(a => a.TypeName).ToListAsync();
            foreach (var bookType in bookTypeList)
            {
                model.BookTypes.Add(new BaseSelectModel(bookType.BookTypeID.ToString(),bookType.TypeName));
            }

            var publisherList = await publisherService.GetAll().OrderBy(a => a.PublisherName).ToListAsync();
            foreach (var publisher in publisherList)
            {
                model.Publishers.Add(new BaseSelectModel(publisher.PublisherID.ToString(), publisher.PublisherName));
            }
            return View(model);
        }

        //POST:Add book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            var authorList = await authorService.GetAll().OrderBy(a => a.NameSurname).ToListAsync();
            foreach (var author in authorList)
            {
                model.Authors.Add(new BaseSelectModel(author.AuthorID.ToString(), author.NameSurname));
            }

            var bookTypeList = await bookTypeService.GetAll().OrderBy(a => a.TypeName).ToListAsync();
            foreach (var bookType in bookTypeList)
            {
                model.BookTypes.Add(new BaseSelectModel(bookType.BookTypeID.ToString(), bookType.TypeName));
            }

            var publisherList = await publisherService.GetAll().OrderBy(a => a.PublisherName).ToListAsync();
            foreach (var publisher in publisherList)
            {
                model.Publishers.Add(new BaseSelectModel(publisher.PublisherID.ToString(), publisher.PublisherName));
            }

            if (ModelState.IsValid)
            {
                model.Book.AvailableQuantity = model.Book.TotalQuantity;

                model.Book.LastUpdatedDate = model.Book.CreatedDate = DateTime.Now;
                var result = await bookService.AddAsync(model.Book,model.SelectedAuthors);
                if (result.isSuccess)
                {
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var r in result.Errors)
                    {
                        ModelState.AddModelError("",r);
                    }
                }
            }

            return View(model);
        }



        [HttpPost]
        public IActionResult Search(string id)
        {
            var model = new BaseOperationModel();
            List<BaseSelectModel> result = bookService.SearchForBooksForSelecting(id).ToList();
            model.Message = result.Count().ToString() + " Eşleşen kitap bulundu";
            if (result.Count() > 0)
            {
                model.isSuccess = true;
                model.Data = result;
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id=0)
        {
            var baseModel = new BaseOperationModel();
            var book = await bookService.GetAsync(a => a.BookID == id);
            if(book !=null)
            {
                var result = await bookService.DeleteAsync(book);
                baseModel.isSuccess = result.isSuccess;
                baseModel.Message = String.Join(";", result.Errors);
            }
            else
            {
                baseModel.Message = "Kitap bulunamadı";
            }
            return Ok(baseModel);
        }

        public async Task<IActionResult> Edit(int id=0)
        {
            if (id == 0)
                return RedirectToAction("Index");
            var book = await bookService.GetAsync(a => a.BookID == id);
            if(book==null)
                return RedirectToAction("Index");
            var model = new EditBookViewModel();
            model.Book.BookID = book.BookID;
            model.Book.BookName = book.BookName;
            model.Book.BookTypeID = book.BookTypeID;
            model.Book.TotalQuantity = book.TotalQuantity;
            model.Book.PublisherID = book.PublisherID;
            model.Book.SayfaSayısı = book.SayfaSayısı;
            model.Book.BookSummary = book.BookSummary;
            model.Book.Location = book.Location;
            model.Book.ISBN = book.ISBN;
            var publishers = publisherService.GetAll().OrderBy(a => a.PublisherName).Select(a => new BaseSelectModel()
            {
                Key = a.PublisherID.ToString(),
                Value = a.PublisherName
            });

            var bookTypes = bookTypeService.GetAll().OrderBy(a => a.TypeName).Select(a => new BaseSelectModel()
            {
                Key = a.BookTypeID.ToString(),
                Value = a.TypeName
            });

            var authors = authorService.GetAll().OrderBy(a => a.NameSurname).Select(a => new BaseSelectModel()
            {
                Key = a.AuthorID.ToString(),
                Value = a.NameSurname
            });
            model.Publishers.AddRange(publishers);
            model.Authors.AddRange(authors);
            model.BookTypes.AddRange(bookTypes);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = await bookService.GetAsync(a => a.BookID == model.Book.BookID);
                if (book == null)
                    return RedirectToAction("Index");
                book.BookName = model.Book.BookName.ToUpper();
                book.BookSummary = model.Book.BookSummary;
                book.BookTypeID = model.Book.BookTypeID;
                book.SayfaSayısı = model.Book.SayfaSayısı;
                book.ISBN = model.Book.ISBN;
                book.LastUpdatedDate = DateTime.Now;
                book.PublisherID = model.Book.PublisherID;

                

                var result = await bookService.UpdateAsync(book);
                if (result.isSuccess)
                    return RedirectToAction("Index");
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }

            }
            var publishers = publisherService.GetAll().OrderBy(a => a.PublisherName).Select(a => new BaseSelectModel()
            {
                Key = a.PublisherID.ToString(),
                Value = a.PublisherName
            });

            var bookTypes = bookTypeService.GetAll().OrderBy(a => a.TypeName).Select(a => new BaseSelectModel()
            {
                Key = a.BookTypeID.ToString(),
                Value = a.TypeName
            });

            var authors = authorService.GetAll().OrderBy(a => a.NameSurname).Select(a => new BaseSelectModel()
            {
                Key = a.AuthorID.ToString(),
                Value = a.NameSurname
            });
            model.Publishers.AddRange(publishers);
            model.Authors.AddRange(authors);
            model.BookTypes.AddRange(bookTypes);
            return View(model);

        }
    }
}