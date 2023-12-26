using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Repositories;

namespace LibraryTestProject.DAL.Repositories
{
    public class RoomRepositoryTests
    {
        [Fact]
        public void GetByIdOrDefault_ReturnsRoom_WhenRoomExists()
        {
            // Arrange
            var repository = new RoomRepository();
            var room = new Room { RoomId = 1, Number = 101 };
            repository.Add(room);

            // Act
            var result = repository.GetByIdOrDefault(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.RoomId);
        }

        [Fact]
        public void GetByIdOrDefault_ReturnsNull_WhenRoomDoesNotExist()
        {
            // Arrange
            var repository = new RoomRepository();

            // Act
            var result = repository.GetByIdOrDefault(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetLastKeyIdPlusOne_ReturnsNextKeyId()
        {
            // Arrange
            var repository = new RoomRepository();
            repository.Add(new Room { RoomId = 1, Number = 101 });
            repository.Add(new Room { RoomId = 2, Number = 102 });

            // Act
            var result = repository.GetLastKeyIdPlusOne();

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_ThrowsException_WhenRoomIdIsZero()
        {
            // Arrange
            var repository = new RoomRepository();
            var room = new Room { RoomId = 0, Number = 101 };

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => repository.Add(room));
            Assert.Equal("Room id can't be 0.", exception.Message);
        }

        [Fact]
        public void Add_ThrowsException_WhenRoomNumberIsZero()
        {
            // Arrange
            var repository = new RoomRepository();
            var room = new Room { RoomId = 1, Number = 0 };

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => repository.Add(room));
            Assert.Equal("Room number should be greater than 0.", exception.Message);
        }

    }
}