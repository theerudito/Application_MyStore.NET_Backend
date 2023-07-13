using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MBrand
    {
        [Key]
        public int IdBrand { get; set; }

        public string Brand { get; set; } = string.Empty;
    }
}