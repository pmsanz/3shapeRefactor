using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryConsoleApp.DAL.Entities
{
    public class Row
    {
        [Key]
        public long RowId { get; set; }
        [Required]
        public long RoomId { get; set; }
        public int Number { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

    }
}
