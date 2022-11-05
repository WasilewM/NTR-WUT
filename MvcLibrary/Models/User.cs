using System.ComponentModel.DataAnnotations;

namespace MvcLibrary.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }
    }
}
