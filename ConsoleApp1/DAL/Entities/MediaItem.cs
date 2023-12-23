using LibraryConsoleApp.DAL.Interfaces;


namespace LibraryConsoleApp.DAL.Entities
{
    public class MediaItem : LibraryItem, IMediaItem
    {
        public List<Track> Tracks { get; set; }
        public int Capacity { get; set; }

        public MediaItem(List<Track> tracks, int capacity, string title, string isbn)
        {
            ISBN = isbn;
            Title = title;
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
