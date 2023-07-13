using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MAuth
    {
        [Key]
        public int IdAuth { get; set; }

        [MaxLength(60)]
        public string User { get; set; } = string.Empty;

        [MaxLength(60)]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Direction { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Role { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}