using LibraryConsoleApp.BLL.Interfaces;
using LibraryConsoleApp.DAL.Entities;

namespace LibraryConsoleApp.BLL.Implementations
{
    public class BookParser : IParser<Book>
    {
        public List<Book> Read(string input)
        {
            List<Book> books = new List<Book>();
            string[] bookData = input.Split(new string[] { "Book:" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string bookInfo in bookData)
            {
                string[] lines = bookInfo.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries);
                List<string> authors = new List<string>();
                string? title = null;
                string? publisher = null;
                int publicationYear = 0;
                int pages = 0;

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length != 2)
                    {
                        continue;
                    }

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch (key)
                    {
                        case "Author":
                            authors.Add(value);
                            break;
                        case "Title":
                            title = value;
                            break;
                        case "Publisher":
                            publisher = value;
                            break;
                        case "Published":
                            if (int.TryParse(value, out int publishedYear))
                            {
                                publicationYear = publishedYear;
                            }
                            break;
                        case "NumberOfPages":
                            if (int.TryParse(value, out int pageCount))
                            {
                                pages = pageCount;
                            }
                            break;
                    }
                }

                if (authors.Count != 0 && title != null && publisher != null && publicationYear > 0 && pages > 0)
                {
                    books.Add(new Book(authors, title, Guid.NewGuid().ToString(), publisher, pages, publicationYear));
                }
            }

            return books;
        }

    }
}
