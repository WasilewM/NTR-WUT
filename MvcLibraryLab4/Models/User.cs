using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcLibraryLab4.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "decimal(1,0)")]
        [Range(0, 1)]
        [Required]
        public int IsLibrarian { get; set; } = 0;

        [DataType(DataType.Date)]
        public DateTime? TimeStamp { get; set; } = DateTime.Now;
    }
}
