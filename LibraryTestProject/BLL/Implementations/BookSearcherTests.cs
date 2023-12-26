using LibraryConsoleApp.BLL.Implementations;
using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Repositories;

namespace LibraryTestProject.BLL.Implementations
{
    public class BookSearcherTests
    {

        BookRepository bookRepository = new BookRepository();

        public BookSearcherTests()
        {
            List<Book> Items = new List<Book>
            {
                new Book(new List<string> { "Author X" },1,"title X","ISBN1","publisher X",999,2012,false),
                new Book(new List<string> { "Author Y" },1,"title Y","ISBN2","publisher Y",888,2011,false),
                new Book(new List<string> { "Author Z" },1,"title Z","ISBN3","publisher Z",777,2001,false)
            };
            bookRepository.Items = Items;
        }

        [Fact]
        public void Find_WithEmptySearchString_ReturnsEmptyList()
        {
            // Arrange
            BookSearcher searcher = new BookSearcher(bookRepository, new QuerySanitizerImplementation());

            // Act
            var result = searcher.Find("");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Find_WithMatchingProperty_ReturnsMatchingBooks()
        {
            // Arrange
            BookSearcher searcher = new BookSearcher(bookRepository, new QuerySanitizerImplementation());

            // Act
            var result = searcher.Find("*Z *");

            // Assert
            Assert.Single(result);
            Assert.Equal("Author Z", result[0].Authors[0]);
        }

        [Fact]
        public void Find_WithMatchingProperties_ReturnsMatchingBooks()
        {
            // Arrange
            BookSearcher searcher = new BookSearcher(bookRepository, new QuerySanitizerImplementation());

            // Act
            var result = searcher.Find("*Author * &*title X *");

            // Assert
            Assert.Single(result);
            Assert.Equal("Author X", result[0].Authors[0]);
        }

        // Add more test methods to cover other scenarios and edge cases

        [Fact]
        public void SearchItemByISBNorDefault_WithInvalidISBN_ThrowsArgumentException()
        {
            // Arrange
            BookSearcher searcher = new BookSearcher(bookRepository, new QuerySanitizerImplementation());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => searcher.SearchItemByISBNorDefault(""));
        }

        [Theory]
        [InlineData("Author X", 1)] // Matching author name
        [InlineData("title Z", 1)]    // Matching ISBN
        [InlineData("publisher Y", 1)] // Matching publisher
        [InlineData("2012", 1)]     // Matching publication year
        public void Find_WithSingleMatchingProperty_ReturnsMatchingBooks(string searchString, int expectedCount)
        {
            // Arrange
            BookSearcher searcher = new BookSearcher(bookRepository, new QuerySanitizerImplementation());

            // Act
            var result = searcher.Find($"*{searchString}*");

            // Assert
            Assert.Equal(expectedCount, result.Count);
        }

        [Theory]
        [InlineData("Author X", "title X", 1)] // Matching author and title
        [InlineData("Author Y", "title Z", 0)] // Matching author and title (no matching book)
        [InlineData("title X", "2012", 1)]       // Matching ISBN and publication year
        [InlineData("publisher Z", "2011", 0)] // Matching publisher and publication year (no matching book)
        public void Find_WithMultipleMatchingProperties_ReturnsMatchingBooks(
            string query1, string query2, int expectedCount)
        {
            // Arrange
            BookSearcher searcher = new BookSearcher(bookRepository, new QuerySanitizerImplementation());

            // Act
            var result = searcher.Find($"*{query1}* & *{query2}*");

            // Assert
            Assert.Equal(expectedCount, result.Count);
        }
    }
}
