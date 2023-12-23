using LibraryConsoleApp.DAL.Entities;

namespace LibraryConsoleApp.DAL.Interfaces
{
    public interface IMediaItem
    {
        public List<Track> Tracks { get; set; }
        public int Capacity { get; set; }

    }
}
