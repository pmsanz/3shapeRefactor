namespace LibraryConsoleApp.BLL.Interfaces
{
    public interface LibraryItemSearcher<T>
    {
        public T? SearchItemByISBNorDefault(string isbn);
    }
}
