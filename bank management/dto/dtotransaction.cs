using System.ComponentModel.DataAnnotations;

namespace bank_management.dto
{
    public class dtotransaction
    {
        [Required]
        public int amount { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
