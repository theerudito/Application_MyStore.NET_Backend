using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MCode
    {
        [Key]
        public int IdCode { get; set; }

        public string Code { get; set; } = string.Empty;
    }
}