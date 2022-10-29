using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        
        [Column(TypeName  = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
