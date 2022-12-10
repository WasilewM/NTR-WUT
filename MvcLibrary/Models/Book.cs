using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string? Title { get; set; }

        [RegularExpression(@"^[-\'A-Za-z\s]$")]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string? Author { get; set; }

        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string? Genre { get; set; }

        [Display(Name = "Pages Number")]
        [Column(TypeName  = "decimal(18, 0)")]
        [Range(1,10000)]
        [Required]
        public int PagesNumber { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? ReservedUntil { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? LentUntil { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
