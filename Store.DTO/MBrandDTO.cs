using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class MBrandDTO
    {
        [Key]
        public int IdBrand { get; set; }

        public string Brand { get; set; } = string.Empty;
    }
}