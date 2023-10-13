using Microsoft.AspNetCore.Mvc;
using MvcRepositoryPatternDemo.DAL;
using MvcRepositoryPatternDemo.Models;
using System.Data;

namespace MvcRepositoryPatternDemo.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext _context;
        private readonly IBookRepository _bookRepository;

        public BookController(BookContext context, IBookRepository bookRepository) 
        {
            _context = context;
            _bookRepository = bookRepository;
        }

        #region List of Books
        public IActionResult Index()
        {
          //var books = from b in _bookRepository.GetBooks() 
          //            select b;
          //            return View(books);
            var books = _bookRepository.GetBooks();
            return View(books);
        }
        #endregion

        #region Details
        public ViewResult Details(long id)
        {
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
         public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.AddBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again");
            }
            return View(book);
        }
        #endregion

        #region Edit 
        public ActionResult Edit(long id)
        {
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.UpdateBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again");
            }
            return View(book);
        }
        #endregion

        #region Delete
        public ActionResult Delete(long id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again";
            }
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(long id)
        {
            try
            {
                Book book = _bookRepository.GetBookById(id);
                _bookRepository.DeleteBook(id);
                _bookRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            _bookRepository.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}
