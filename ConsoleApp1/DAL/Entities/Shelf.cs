using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryConsoleApp.DAL.Entities
{
    public class Shelf
    {
        [Key]
        public long ShelfId { get; set; }
        [Required]
        public long RowId { get; set; }
        public int Number { get; set; }
        [ForeignKey("RowId")]
        public virtual Row Row { get; set; }
    }
}
