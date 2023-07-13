using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MCompany
    {
        [Key]
        public int IdCompany { get; set; }

        [MaxLength(80)]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(80)]
        public string OwnerCompany { get; set; } = string.Empty;

        [MaxLength(80)]
        public string DirectionCompany { get; set; } = string.Empty;

        [MaxLength(50)]
        public string EmailCompany { get; set; } = string.Empty;

        [MaxLength(20)]
        public string DNICompany { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneCompany { get; set; } = string.Empty;

        [MaxLength(50)]
        public string NumDocumentCompany { get; set; } = string.Empty;

        [MaxLength(10)]
        public string SerieOneCompany { get; set; } = string.Empty;

        [MaxLength(10)]
        public string SerieTwoCompany { get; set; } = string.Empty;

        [MaxLength(50)]
        public string DataBaseName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string TypeDocument { get; set; } = string.Empty;

        public decimal IvaCompany { get; set; }

        [MaxLength(10)]
        public string CoinCompany { get; set; } = string.Empty;
    }
}