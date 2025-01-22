using System.ComponentModel.DataAnnotations;

namespace bank_management.models
{
    public class transaction
    {
        public int id { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public DateTime date { get; set; }
        public account? account { get; set; }
        public int account_id { get; set; }
    }
}
