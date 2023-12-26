namespace LibraryConsoleApp.BLL.Interfaces
{
    public interface IQuerySearcheable<T>
    {
        bool MatchItem(T item, string searchTerm);
        List<T> Find(string searchString);
    }
}
