using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class MCityDTO
    {
        [Key]
        public int IdCity { get; set; }

        public string City { get; set; } = string.Empty;
    }
}