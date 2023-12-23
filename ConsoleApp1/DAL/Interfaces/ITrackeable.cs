namespace LibraryConsoleApp.DAL.Interfaces
{
    public interface ITrackeable
    {
        public string Title { get; }
        public string Artist { get; }
        public TimeSpan Duration { get; }
    }
}
