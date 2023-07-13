using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MCity
    {
        [Key]
        public int IdCity { get; set; }

        public string City { get; set; } = string.Empty;
    }
}