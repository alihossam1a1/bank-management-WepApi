using System.ComponentModel.DataAnnotations;

namespace bank_management.models
{
    public class branch
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string location { get; set; }
        public List<employee>? employees { get; set; }

    }
}
