using LibraryConsoleApp.BLL.Interfaces;
using LibraryConsoleApp.DAL.Entities;

namespace LibraryConsoleApp.BLL.Implementations
{
    public class LibrarySearcher
    {
        private ISearcher<Book> _bookSearcher;
        public LibrarySearcher(ISearcher<Book> bookSearcher)
        {
            _bookSearcher = bookSearcher;
        }
        public List<Book> FindBooks(string searchString) => _bookSearcher.Find(searchString);
    }
}
