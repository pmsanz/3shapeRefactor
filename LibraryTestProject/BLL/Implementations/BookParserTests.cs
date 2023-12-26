using LibraryConsoleApp.BLL.Implementations;
using LibraryConsoleApp.DAL.Entities;

namespace LibraryTestProject.BLL.Implementations
{
    public class BookParserTests
    {
        [Fact]
        public void Read_WithValidInput_ReturnsListOfBooks()
        {
            // Arrange
            var bookReader = new BookParser();
            string input = "Book:\r\nAuthor: Brian Jensen\r\nTitle: Texts from Denmark\r\nPublisher: Gyldendal\r\nPublished: 2001\r\nNumberOfPages: 253\r\n \r\nBook:\r\nAuthor: Peter Jensen\r\nAuthor: Hans Andersen\r\nTitle: Stories from abroad\r\nPublisher: Borgen\r\nPublished: 2012\r\nNumberOfPages: 156\r\n";
            // Act
            List<Book> result = bookReader.Read(input);

            // Assert Book 1
            Assert.NotNull(result);
            Assert.Equal("Brian Jensen", result[0].Authors[0]);
            Assert.Equal("Texts from Denmark", result[0].Title);
            Assert.Equal("Gyldendal", result[0].Publisher);
            Assert.Equal(2001, result[0].PublicationYear);
            Assert.Equal(253, result[0].NumberOfPages);
            // Assert Book 2
            Assert.Equal("Peter Jensen", result[1].Authors[0]);
            Assert.Equal("Hans Andersen", result[1].Authors[1]);
            Assert.Equal("Stories from abroad", result[1].Title);
            Assert.Equal("Borgen", result[1].Publisher);
            Assert.Equal(2012, result[1].PublicationYear);
            Assert.Equal(156, result[1].NumberOfPages);
        }

        [Fact]
        public void Read_WithEmptyInput_ThrowsArgumentNullException()
        {
            // Arrange
            var bookReader = new BookParser();
            string input = "";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bookReader.Read(input));
        }
    }
}