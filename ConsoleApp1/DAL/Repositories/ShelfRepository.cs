using LibraryConsoleApp.DAL.Entities;

namespace LibraryConsoleApp.DAL.Repositories
{
    public class ShelfRepository : Repository<Shelf>
    {
        public override Shelf? GetByIdOrDefault(long id)
        {
            return Items.FirstOrDefault(x => x.ShelfId == id);
        }

        public override long GetLastKeyIdPlusOne()
        {
            return Items.Max(x => x.RowId) + 1;
        }

        protected override void CheckConstraints(Shelf item)
        {
            if (item.ShelfId == 0)
                throw new InvalidOperationException("ShelfId id can't be 0.");
            if (item.RowId == 0)
                throw new InvalidOperationException("RowId id can't be 0.");
            if (item.Number == 0)
                throw new InvalidOperationException("Shelf number should be greather than 0.");

        }

    }
}
