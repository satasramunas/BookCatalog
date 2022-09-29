using BookCatalog.Dtos;
using BookCatalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BorrowBook(int id)
        {
            var book = await _bookService.GetById(id);

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBook(BookDto book)
        {
            await _bookService.BorrowBook(book);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(string searchString)
        {
            List<BookDto> books = await _bookService.GetAll();

            List<BookDto> availableBooks = await _bookService.GetAvailableBooks();

            List<BookDto> borrowedBooks = await _bookService.GetBorrowedBooks();

            if (!String.IsNullOrEmpty(searchString))
            {
                availableBooks = availableBooks.Where(b => b.Title.ToLower().Contains(searchString)
                || b.Author.ToLower().Contains(searchString) || b.Genre.ToLower().Contains(searchString)
                || b.Publisher.ToLower().Contains(searchString) || b.ISBNCode.ToLower().Contains(searchString)
                || b.PublishingDate.ToLower().Equals(searchString) || b.IsAvailable.Equals(searchString)).ToList();
            }

            var viewModel = new BookDto
            {
                Books = books,
                AvailableBooks = availableBooks,
                BorrowedBooks = borrowedBooks
            };
            

            return View(viewModel);
        }
        
        public async Task<IActionResult> Admin()
        {
            List<BookDto> returnedBooks = await _bookService.GetReturnedBooks();

            var viewModel = new BookDto
            {
                ReturnedBooks = returnedBooks
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ReturnBook(BookDto book)
        {
            await _bookService.ReturnBook(book);

            return RedirectToAction("Index");
        }
    }
}
