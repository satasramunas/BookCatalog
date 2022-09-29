using AutoMapper;
using BookCatalog.Dtos;
using BookCatalog.Models;
using BookCatalog.Repositories;

namespace BookCatalog.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(BookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAll()
        {
            var entities = await _bookRepository.GetAllAsync();

            List<BookDto> bookDtos = _mapper.Map<List<BookDto>>(entities);

            return bookDtos;
        }

        public async Task<BookDto> GetById(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);

            BookDto bookDto = _mapper.Map<BookDto>(entity);

            return bookDto;
        }

        public async Task BorrowBook(BookDto bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto);

            await _bookRepository.BorrowBookAsync(entity);
        }

        public async Task ReturnBook(BookDto bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto);

            await _bookRepository.ReturnBookAsync(entity);
        }

        public async Task<List<BookDto>> GetBorrowedBooks()
        {
            var entities = await _bookRepository.GetBorrowedBooksAsync();

            List<BookDto> bookDto = _mapper.Map<List<BookDto>>(entities);

            return bookDto;
        }

        public async Task<List<BookDto>> GetAvailableBooks()
        {
            var entities = await _bookRepository.GetAvailableBooksAsync();

            List<BookDto> bookDto = _mapper.Map<List<BookDto>>(entities);

            return bookDto;
        }

        public async Task<List<BookDto>> GetReturnedBooks()
        {
            var entities = await _bookRepository.GetReturnedBooksAsync();

            List<BookDto> bookDto = _mapper.Map<List<BookDto>>(entities);

            return bookDto;
        }
    }
}
