namespace LibraryConsoleApp.BLL.Interfaces
{
    public interface IQuerySanitizer
    {
        List<string> SanitizeQueryText(string searchString);
    }
}
