using System.ComponentModel.DataAnnotations;

namespace bank_management.dto
{
    public class updateaccountcustomer
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [MaxLength(15)]
        public string phone { get; set; }
        
    }
}
