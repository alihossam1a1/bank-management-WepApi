using System.ComponentModel.DataAnnotations;

namespace bank_management.dto
{
    public class accountadddto
    {
        [Required]
        [MaxLength(20)]
        public string accountnumber { get; set; }
        [Required]
        public int balance { get; set; }
        public int customerid { get; set; }
        public dtocustomer? dtocustomer { get; set; }
    }
}
