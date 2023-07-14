using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class MAuthDTO
    {
        [MaxLength(60)]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(60)]
        public string Password { get; set; } = string.Empty;
    }
}
