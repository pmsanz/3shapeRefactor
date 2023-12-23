namespace LibraryConsoleApp.DAL.Interfaces
{
    public interface ILibraryItem
    {
        long ItemId { get; }
        long ShelfId { get; }
        string Title { get; }
        string ISBN { get; }
        bool IsAvailable { get; }
        void Borrow();
        void Return();

    }
}
