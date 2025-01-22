using System.ComponentModel.DataAnnotations;

namespace bank_management.dto
{
    public class updateaccountdto
    {


        [Required]
        [MaxLength(20)]
        public string accountnumber { get; set; }
        [Required]
        public int balance { get; set; }
        public int customerid { get; set; }
        public updateaccountcustomer? updateaccountcustomer { get; set; }
        public List<dtotransaction>? dtotransactions { get; set; }
    }
}
