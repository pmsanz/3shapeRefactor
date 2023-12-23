namespace LibraryConsoleApp.DAL.Entities
{
    public class Book : LibraryItem
    {
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }

        public Book(List<string> authors, string title, string isbn, string publisher, int numberOfPages, int publicationYear)
        {
            Title = title;
            ISBN = isbn;
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
