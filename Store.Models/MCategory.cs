using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MCategory
    {
        [Key]
        public int IdCategory { get; set; }

        public string Category { get; set; } = string.Empty;
    }
}