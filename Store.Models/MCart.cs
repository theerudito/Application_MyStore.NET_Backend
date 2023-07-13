using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class MCart
    {
        [Key]
        public int IdCart { get; set; }

        public int IdProduct { get; set; }
        public MProducts? Products { get; set; }
        public int IdClient { get; set; }
        public MClients? Clients { get; set; }
    }
}