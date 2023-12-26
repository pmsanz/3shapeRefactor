using LibraryConsoleApp.BLL.Implementations;
using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Repositories;

namespace LibraryConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Book> Items = new List<Book>()
            {
                new Book(new List<string> { "Author1", "Author2" }, 1, "Book1", "ISBN1", "Publisher1", 300, 2020, true),
                new Book(new List<string> { "Author3" }, 2, "Book2", "ISBN2", "Publisher2", 250, 2019, true),
                new Book(new List<string> { "Author4", "Author5" }, 3, "Book3", "ISBN3", "Publisher3", 400, 2021, true)
            };
            BookRepository bookRepository = new BookRepository();
            bookRepository.Items = Items;
            BookSearcher bookSearcher = new BookSearcher(bookRepository, new QuerySanitizerImplementation());
            var book = bookSearcher.SearchItemByISBNorDefault("ISBN1");
        }
    }
}
