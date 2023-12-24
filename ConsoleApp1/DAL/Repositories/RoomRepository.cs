using LibraryConsoleApp.DAL.Entities;
using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.DAL.Repositories
{
    public class RoomRepository : Repository<Room>
    {
        public override Room? GetByIdOrDefault(long id)
        {
            return Items.FirstOrDefault(x => x.RoomId == id);
        }

        public override long GetLastKeyIdPlusOne()
        {
            return Items.Max(x => x.RoomId) + 1;
        }

        protected override void CheckConstraints(Room item)
        {
            if (item.RoomId == 0)
                throw new InvalidOperationException("Room id can't be 0.");
            if (item.Number == 0)
                throw new InvalidOperationException("Room number should be greather than 0.");
        }
    }
}
