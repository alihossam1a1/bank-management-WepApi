using System.ComponentModel.DataAnnotations;

namespace bank_management.models
{
    public class employee
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string position { get; set; }
        public List<branch>? branch { get; set; }

    }
}
