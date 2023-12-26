using LibraryConsoleApp.BLL.Implementations;
using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.BLL.Interfaces
{
    public interface ILibrary
    {

        public IRepository<Room> RoomRepository { get; }
        public IRepository<Row> RowRepository { get; }
        public IRepository<Shelf> ShelfRepository { get; }
        public IRepository<LibraryItem> LibraryRepository { get; }
        public Repository<Book> BookRepository { get; }
        public BookSearcher BookSearcher { get; }

        public List<Book> GetBooksByRoomId(long id);
        public List<Book> GetBooksByRowId(long id);
        public List<Book> GetBooksByShelfId(long id);


    }
}
