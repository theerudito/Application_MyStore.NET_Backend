using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class MProductsDTO
    {
        [Key]
        public int IdProduct { get; set; }

        [MaxLength(60)]
        public string NameProduct { get; set; } = string.Empty;

        [MaxLength(60)]
        public string CodeProduct { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Brand { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(80)]
        public string Description { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal PriceUnitary { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal PriceTotal { get; set; }

        public int Quantity { get; set; }
        public bool Status { get; set; } = true;
        public bool Iva { get; set; } = true;
    }
}