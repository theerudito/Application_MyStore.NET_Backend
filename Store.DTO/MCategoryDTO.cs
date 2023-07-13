using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class MCategoryDTO
    {
        [Key]
        public int IdCategory { get; set; }

        public string Category { get; set; } = string.Empty;
    }
}