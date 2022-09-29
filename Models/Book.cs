namespace BookCatalog.Models
{
    public enum Status
    {
        Available,
        Taken,
        Returned
    }

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string PublishingDate { get; set; }

        public string Genre { get; set; }

        public string ISBNCode { get; set; }

        public Status IsAvailable { get; set; }

        public List<Book> Books { get; set; }

        public List<Book> BorrowedBooks { get; set; }

        public List<Book> AvailableBooks { get; set; }

        public List<Book> ReturnedBooks { get; set; }
    }
}
