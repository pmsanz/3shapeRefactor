using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.DAL.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public override Book? GetByIdOrDefault(long id)
        {
            return Items.FirstOrDefault(x => x.ItemId == id);
        }

        public override long GetLastKeyIdPlusOne()
        {
            return Items.Max(x => x.ItemId) + 1;
        }

        protected override void CheckConstraints(Book item)
        {
            if (item.ItemId == 0)
                throw new ArgumentException("Item id of this Book should be greater than 0.");
            if (item.ShelfId == 0)
                throw new ArgumentException("ShelfId should be setted.");
            if (string.IsNullOrEmpty(item.ISBN))
                throw new ArgumentException("ISBN cannot be empty");

        }
    }
}
