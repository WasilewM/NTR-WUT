using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTRLab4Backend.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string? Genre { get; set; }

        [Column(TypeName  = "decimal(18, 0)")]
        public int PagesNumber { get; set; }

        // [ForeignKey("User")]
        // public int? UserId { get; set; }
        // @TODO: Fix me
        public string? Username { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReservedUntil { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? LentUntil { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
