using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Repositories;

namespace LibraryTestProject.DAL.Repositories
{
    public class ShelfRepositoryTests
    {
        [Fact]
        public void GetByIdOrDefault_ShouldReturnShelfWithMatchingId()
        {
            // Arrange
            var repository = new ShelfRepository();
            var shelf = new Shelf { ShelfId = 1, RowId = 1, Number = 1 };
            repository.Add(shelf);

            // Act
            var result = repository.GetByIdOrDefault(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(shelf, result);
        }

        [Fact]
        public void GetByIdOrDefault_ShouldReturnNullWhenIdNotFound()
        {
            // Arrange
            var repository = new ShelfRepository();
            var shelf = new Shelf { ShelfId = 1, RowId = 1, Number = 1 };
            repository.Add(shelf);

            // Act
            var result = repository.GetByIdOrDefault(2);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetLastKeyIdPlusOne_ShouldReturnNextAvailableKeyId()
        {
            // Arrange
            var repository = new ShelfRepository();
            repository.Add(new Shelf { ShelfId = 1, RowId = 1, Number = 1 });
            repository.Add(new Shelf { ShelfId = 2, RowId = 1, Number = 1 });

            // Act
            var result = repository.GetLastKeyIdPlusOne();

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_ShouldThrowExceptionWhenShelfIdIsZero()
        {
            // Arrange
            var repository = new ShelfRepository();
            var shelf = new Shelf { ShelfId = 0 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repository.Add(shelf));
        }

        [Fact]
        public void Add_ShouldThrowExceptionWhenRowIdIsZero()
        {
            // Arrange
            var repository = new ShelfRepository();
            var shelf = new Shelf { ShelfId = 1, RowId = 0 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repository.Add(shelf));
        }

        [Fact]
        public void Add_ShouldThrowExceptionWhenShelfNumberIsZero()
        {
            // Arrange
            var repository = new ShelfRepository();
            var shelf = new Shelf { ShelfId = 1, RowId = 1, Number = 0 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repository.Add(shelf));
        }
    }
}
