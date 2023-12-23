using System.ComponentModel.DataAnnotations;

namespace LibraryConsoleApp.DAL.Entities
{
    public class Room
    {
        [Key]
        public long RoomId { get; set; }
        public int Number { get; set; }
    }
}
