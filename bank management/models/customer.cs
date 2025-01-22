using System.ComponentModel.DataAnnotations;

namespace bank_management.models
{
    public class customer
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [MaxLength(15)]
        public string phone { get; set; }
        
        public bankcard? bankcard { get; set; }
        public int bankcardid { get; set; }
        public List<account>? accounts  { get; set; }
    }
}
