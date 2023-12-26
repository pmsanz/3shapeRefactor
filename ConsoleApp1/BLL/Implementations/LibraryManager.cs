using LibraryConsoleApp.BLL.Interfaces;
using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Interfaces;
using LibraryConsoleApp.DAL.Repositories;

namespace LibraryConsoleApp.BLL.Implementations
{
    public class LibraryManager : ILibrary, LibraryItemSearcher<LibraryItem>
    {
        public List<LibraryItem> Items { get; set; }
        public BookSearcher BookSearcher { get; set; }
        public IRepository<Room> RoomRepository { get; set; }
        public IRepository<Row> RowRepository { get; set; }
        public IRepository<Shelf> ShelfRepository { get; set; }
        public IRepository<LibraryItem> LibraryRepository { get; set; }
        public Repository<Book> BookRepository { get; set; }


        public LibraryManager()
        {
            LibraryRepository = new LibraryItemRepository();
            BookRepository = new BookRepository();
            BookSearcher = new BookSearcher(BookRepository, new QuerySanitizerImplementation());
            RoomRepository = new RoomRepository();
            RowRepository = new RowRepository();
            ShelfRepository = new ShelfRepository();
        }

        public List<Book> GetBooksByRoomId(long id)
        {
            if (id == 0)
                throw new ArgumentException("id should be greater than 0.");
            //inner join
            var room = RoomRepository.GetByIdOrDefault(id);
            var row = RowRepository.GetByIdOrDefault(room.RoomId);
            var shelf = ShelfRepository.GetByIdOrDefault(row.RowId);
            if (shelf != null)
                return BookRepository.Items.Where(x => x.ShelfId == shelf.ShelfId).ToList();
            return new List<Book>();
        }

        public List<Book> GetBooksByRowId(long id)
        {
            if (id == 0)
                throw new ArgumentException("id should be greater than 0.");
            //inner join
            var row = RowRepository.GetByIdOrDefault(id);
            var shelf = ShelfRepository.GetByIdOrDefault(row.RowId);
            if (shelf != null)
                return BookRepository.Items.Where(x => x.ShelfId == shelf.ShelfId).ToList();
            return new List<Book>();
        }

        public List<Book> GetBooksByShelfId(long id)
        {
            if (id == 0)
                throw new ArgumentException("id should be greater than 0.");

            var shelf = ShelfRepository.GetByIdOrDefault(id);
            if (shelf != null)
                return BookRepository.Items.Where(x => x.ShelfId == shelf.ShelfId).ToList();
            return new List<Book>();
        }

        public LibraryItem? SearchItemByISBNorDefault(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                throw new ArgumentException("ISBN should have a value");
            return Items.FirstOrDefault(x => x.ISBN == isbn);

        }

    }
}
