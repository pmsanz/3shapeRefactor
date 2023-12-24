using LibraryConsoleApp.DAL.Interfaces;


namespace LibraryConsoleApp.DAL.Entities
{
    public class MediaItem : LibraryItem, IMediaItem
    {
        public List<Track> Tracks { get; set; }
        public int Capacity { get; set; }

        public MediaItem(List<Track> tracks, long shaftId, int capacity, string title, string isbn, bool isAvailable) : base(shaftId, title, isbn, isAvailable)
        {
            Tracks = tracks;
            Capacity = capacity;
        }

        public override void Borrow()
        {
            IsAvailable = false;
            Console.WriteLine("Borrowing media item.");
        }

        public override void Return()
        {
            IsAvailable = true;
            Console.WriteLine("Returning media item.");
        }
    }
}
