namespace LibraryConsoleApp.BLL.Interfaces
{
    public interface IParser<T>
    {
        List<T> Read(string input);
    }


}
