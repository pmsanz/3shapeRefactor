using LibraryConsoleApp.BLL.Interfaces;
using LibraryConsoleApp.DAL.Entities;

namespace LibraryConsoleApp.BLL.Implementations
{
    public class LibraryParser
    {
        private IParser<Book> _bookParser;

        public LibraryParser(IParser<Book> bookParser)
        {
            _bookParser = bookParser;
        }

        public List<Book> ReadBooks(string input) => _bookParser.Read(input);
    }
}
