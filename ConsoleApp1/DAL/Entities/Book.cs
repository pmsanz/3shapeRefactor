namespace LibraryConsoleApp.DAL.Entities
{
    public class Book : LibraryItem
    {
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }

        public Book(List<string> authors, long shelfId, string title, string isbn, string publisher, int numberOfPages, int publicationYear, bool isAvailable) : base(shelfId, title, isbn, isAvailable)
        {
            Authors = authors;
            Publisher = publisher;
            PublicationYear = publicationYear;
            NumberOfPages = numberOfPages;
            PublicationYear = publicationYear;
        }

        public void AddAuthor(string author)
        {
            Authors.Add(author);
        }
        public override void Borrow()
        {
            IsAvailable = false;
        }
        public override void Return()
        {
            IsAvailable = true;
        }
    }
}
