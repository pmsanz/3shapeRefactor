using LibraryConsoleApp.BLL.Interfaces;
using LibraryConsoleApp.DAL.Entities;

namespace LibraryConsoleApp.BLL.Implementations
{
    public class BookSearcher : ISearcher<Book>

    {
        public List<Book> Items { get; set; }
        private IQuerySanitizer _sanitizer;
        public BookSearcher()
        {
            _sanitizer = new QuerySanitizerImplementation();
            Items = new List<Book>();
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

                foreach (Book book in Items)
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
            return book.Title.ToLower().Contains(searchTerm) ||
                 book.Authors.Any(author => author.ToLower().Contains(searchTerm)) ||
                 book.Publisher.ToLower().Contains(searchTerm) ||
                 book.PublicationYear.ToString().Contains(searchTerm);
        }

    }
}
