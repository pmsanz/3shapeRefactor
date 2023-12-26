using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.DAL.Repositories
{
    public class LibraryItemRepository : Repository<LibraryItem>
    {
        public override LibraryItem? GetByIdOrDefault(long id)
        {
            return Items.FirstOrDefault(x => x.ItemId == id);
        }

        public override long GetLastKeyIdPlusOne()
        {
            return Items.Max(x => x.ItemId) + 1;
        }

        protected override void CheckConstraints(LibraryItem item)
        {
            if (item.ShelfId == 0)
                throw new InvalidOperationException("ShelfId id can't be 0.");
            if (string.IsNullOrEmpty(item.ISBN))
                throw new InvalidOperationException("ISBN can't be empty");
            if (item.ItemId == 0)
                throw new InvalidOperationException("ItemId id can't be 0.");
        }
    }
}
