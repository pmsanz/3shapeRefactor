using LibraryConsoleApp.BLL.Interfaces;
using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.BLL.Implementations
{
    public class BookSearcher : IQuerySearcheable<Book>, LibraryItemSearcher<Book>

    {
        public IRepository<Book> BookRepository { get; set; }
        private IQuerySanitizer _sanitizer;
        public BookSearcher(IRepository<Book> books, IQuerySanitizer sanitizer)
        {
            _sanitizer = sanitizer;
            BookRepository = books;
        }

        public List<Book> Find(string searchString)
        {
            List<Book> finalResults = new List<Book>();
            List<string> searchTerms = _sanitizer.SanitizeQueryText(searchString);
            List<List<Book>> searchResults = new List<List<Book>>();

            foreach (string term in searchTerms)
            {
                List<Book> termResults = new List<Book>();
                string searchTermNormalized = term.Trim().ToLower();

                foreach (Book book in BookRepository.Items)
                {
                    if (MatchItem(book, searchTermNormalized))
                    {
                        termResults.Add(book);
                    }
                }
                searchResults.Add(termResults);
            }

            finalResults = searchResults.Aggregate((intermediateResults, termResults) => intermediateResults.Intersect(termResults).ToList());

            return finalResults;
        }
        public bool MatchItem(Book book, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return false;

            return book.Title.ToLower().Contains(searchTerm) ||
                     book.Authors.Any(author => author.ToLower().Contains(searchTerm)) ||
                     book.Publisher.ToLower().Contains(searchTerm) ||
                     book.PublicationYear.ToString().Contains(searchTerm);

        }

        public Book? SearchItemByISBNorDefault(string ISBN)
        {
            if (string.IsNullOrEmpty(ISBN))
                throw new ArgumentException("ISBN cannot be null or empty.", nameof(ISBN));

            return BookRepository.Items.FirstOrDefault(x => x.ISBN == ISBN);
        }
    }
}
