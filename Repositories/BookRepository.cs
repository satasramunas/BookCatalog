using BookCatalog.Data;
using BookCatalog.Dtos;
using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;
using Status = BookCatalog.Models.Status;

namespace BookCatalog.Repositories
{
    public class BookRepository
    {
        protected DataContext _dataContext;

        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dataContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _dataContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                throw new Exception();
            }

            return book;
        }

        public async Task BorrowBookAsync(Book book)
        {
            _dataContext.Update(book);

            book.IsAvailable = Status.Taken;

            await _dataContext.SaveChangesAsync();
        }

        public async Task ReturnBookAsync(Book book)
        {
            _dataContext.Update(book);

            book.IsAvailable = Status.Returned;

            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetBorrowedBooksAsync()
        {
            return await _dataContext.Books.Where(b => b.IsAvailable == Status.Taken).ToListAsync();
        }

        public async Task<List<Book>> GetAvailableBooksAsync()
        {
            return await _dataContext.Books.Where(b => b.IsAvailable == Status.Available).ToListAsync();
        }

        public async Task<List<Book>> GetReturnedBooksAsync()
        {
            return await _dataContext.Books.Where(b => b.IsAvailable == Status.Returned).ToListAsync();
        }
    }
}
