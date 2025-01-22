using System.ComponentModel.DataAnnotations;

namespace bank_management.models
{
    public class account
    {
        public int id { get; set; }
        [Required]
        [MaxLength(20)]
        public string accountnumber { get; set; }
        [Required]
        public int balance { get; set; }
        public int customerid { get; set; }
        public customer? customer { get; set; }
        public List<transaction>? transactions { get; set; }
    }
}
