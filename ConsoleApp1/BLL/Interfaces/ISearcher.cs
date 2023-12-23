namespace LibraryConsoleApp.BLL.Interfaces
{
    public interface ISearcher<T>
    {
        public List<T> Items { get; set; }
        bool MatchItem(T book, string searchTerm);
        List<T> Find(string searchString);
    }
}
