using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class MCodeDTO
    {
        [Key]
        public int IdCode { get; set; }

        public string Code { get; set; } = string.Empty;
    }
}