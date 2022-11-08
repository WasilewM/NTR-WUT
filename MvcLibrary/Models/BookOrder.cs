using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace MvcLibrary.Models
{
    public class BookOrder
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [ForeignKey("Book")]
        [Required]
        public int BookId { get; set; }

        [Column(TypeName = "decimal(2,0)")]
        [Required]
        public int BookOrderStatus { get; set; }
    }
}
