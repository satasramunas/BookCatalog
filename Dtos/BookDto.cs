namespace BookCatalog.Dtos
{
    public enum Status
    {
        Available,
        Taken,
        Returned
    }

    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string PublishingDate { get; set; }

        public string Genre { get; set; }

        public string ISBNCode { get; set; }

        public Status IsAvailable { get; set; }

        public List<BookDto> Books { get; set; }

        public List<BookDto> BorrowedBooks { get; set; }

        public List<BookDto> AvailableBooks { get; set; }

        public List<BookDto> ReturnedBooks { get; set; }
    }
}
