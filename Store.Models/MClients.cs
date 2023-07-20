using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MClients
    {
        [Key]
        public int IdClient { get; set; }

        [MaxLength(20)]
        public string DNI { get; set; } = string.Empty;

        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Direction { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
