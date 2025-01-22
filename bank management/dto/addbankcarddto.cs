using System.ComponentModel.DataAnnotations;

namespace bank_management.dto
{
    public class addbankcarddto
    {
        [Required]
        [MaxLength(16)]
        public string cardnumber { get; set; }
        [Required]
        public DateTime expirydate { get; set;}
    }
}
