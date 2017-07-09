using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Books;

namespace WebMVCWithDB.WEB.Areas.Authorized.Controllers
{
    public class BooksController : Controller
    {
        IBooksService repo;
        public BooksController(IBooksService booksDb)
        {
            repo = booksDb;
        }
        // GET: Authorized/Books
        public ViewResult Index(SearchBook search, int page = 1)
        {
            ViewBag.Search = search;
            var books = repo.GetPageWithBooks(page, search);

            return View(books);
        }

        // GET: Authorized/Books/Edit/{id}
        public ViewResult Edit(int id = 0)
        {
            var book = repo.GetBookForEdit(id);
            SetViewBags();

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(ICreateBook book)
        {
            book.Validate(ModelState);

            string errorMsg;
            SetViewBags();

            if (!ModelState.IsValid)
                return View(book);

            if (!repo.SaveBook(book, out errorMsg))
            {
                TempData["Error"] = errorMsg;
                return View(book);
            }

            return RedirectToAction("Index");
        }

        // GET: Authorized/Books/Book/{id}
        public PartialViewResult _BookDetail(int id)
        {
            var book = repo.GetBookById(id);

            return PartialView(book);
        }

        public ActionResult Delete(int id)
        {
            var book = repo.GetBookForEdit(id);

            return View(book);
        }

        private void SetViewBags()
        {          
            ViewBag.Authors = repo.GetAutors();
            ViewBag.Genres = repo.GetGenres();
        }
    }
}