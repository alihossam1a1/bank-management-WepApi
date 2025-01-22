using bank_management.models;
using System.ComponentModel.DataAnnotations;

namespace bank_management.dto
{
    public class getcustomerDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [MaxLength(15)]
        public string phone { get; set; }
        public List<addaccountdto>? addaccountdto { get; set; }
        public addbankcarddto? addbankcarddto { get; set; }
        public int bankcardid { get; set; }
    }
}
