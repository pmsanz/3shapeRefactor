using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.DAL.Repositories
{
    public class RowRepository : Repository<Row>
    {
        public override Row? GetByIdOrDefault(long id)
        {
            return Items.FirstOrDefault(x => x.RowId == id);
        }

        public override long GetLastKeyIdPlusOne()
        {
            return Items.Max(x => x.RowId) + 1;
        }

        protected override void CheckConstraints(Row item)
        {
            if (item.RowId == 0)
                throw new InvalidOperationException("Row id can't be 0.");
            if (item.RoomId == 0)
                throw new InvalidOperationException("Room id can't be 0.");
            if (item.Number == 0)
                throw new InvalidOperationException("Row number should be greater than 0.");
        }

    }
}
