using System.ComponentModel.DataAnnotations;

namespace bank_management.dto
{
    public class addaccountdto
    {
        [Required]
        [MaxLength(20)]
        public string accountnumber { get; set; }
        [Required]
        public int balance { get; set; }
  
    }
}
