using System.ComponentModel.DataAnnotations;

namespace bank_management.models
{
    public class bankcard
    {
        public int id { get; set; }
        [Required]
        [MaxLength(16)]
        public string cardnumber { get; set; }
        [Required]
        public DateTime expirydate { get; set; }
        public customer? customer { get; set; }
        public int customerid { get; set; }
    }
}
