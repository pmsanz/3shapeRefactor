using LibraryConsoleApp.DAL.Interfaces;

namespace LibraryConsoleApp.DAL.Entities
{
    public abstract class Track : ITrackeable
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
