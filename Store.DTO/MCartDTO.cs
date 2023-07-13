using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class MCartDTO
    {
        [Key]
        public int IdCart { get; set; }

        public int IdProduct { get; set; }
        public MProductsDTO? Products { get; set; }
        public int IdClient { get; set; }
        public MClientsDTO? Clients { get; set; }
    }
}