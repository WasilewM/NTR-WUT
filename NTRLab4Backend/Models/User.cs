using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTRLab4Backend.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "decimal(1,0)")]
        public int IsLibrarian { get; set; } = 0;

        [DataType(DataType.Date)]
        public DateTime? TimeStamp { get; set; } = DateTime.Now;
    }
}
