using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Repositories;

namespace LibraryTestProject.DAL.Repositories
{
    public class RowRepositoryTests
    {
        [Fact]
        public void GetByIdOrDefault_ReturnsCorrectItem()
        {
            // Arrange
            var repository = new RowRepository();
            var row1 = new Row { RowId = 1, RoomId = 1, Number = 1 };
            repository.Add(row1);

            // Act
            var result = repository.GetByIdOrDefault(1);

            // Assert
            Assert.Equal(row1, result);
        }

        [Fact]
        public void GetByIdOrDefault_ReturnsNullIfItemNotFound()
        {
            // Arrange
            var repository = new RowRepository();

            // Act
            var result = repository.GetByIdOrDefault(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetLastKeyIdPlusOne_ReturnsCorrectValue()
        {
            // Arrange
            var repository = new RowRepository();
            var row1 = new Row { RowId = 1, RoomId = 1, Number = 1 };
            var row2 = new Row { RowId = 2, RoomId = 1, Number = 2 };
            repository.Add(row1);
            repository.Add(row2);

            // Act
            var result = repository.GetLastKeyIdPlusOne();

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_ThrowsExceptionIfRowIdIsZero()
        {
            // Arrange
            var repository = new RowRepository();
            var row = new Row { RowId = 0 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repository.Add(row));
        }

        [Fact]
        public void Add_ThrowsExceptionIfRoomIdIsZero()
        {
            // Arrange
            var repository = new RowRepository();
            var row = new Row { RowId = 1, RoomId = 0 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repository.Add(row));
        }

        [Fact]
        public void Add_ThrowsExceptionIfRowNumberIsZero()
        {
            // Arrange
            var repository = new RowRepository();
            var row = new Row { RowId = 1, RoomId = 1, Number = 0 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repository.Add(row));
        }
    }
}
