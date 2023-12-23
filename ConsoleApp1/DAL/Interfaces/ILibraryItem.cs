namespace LibraryConsoleApp.DAL.Interfaces
{
    public interface ILibraryItem
    {
        string Title { get; }
        string ISBN { get; }
        bool IsAvailable { get; }
        void Borrow();
        void Return();

    }
}
