using System.ComponentModel.DataAnnotations;

namespace AppView.Models
{
    public class NhanVienViewModel
    {
        public Guid ID { get; set; }
        [Required]
        [Length(1,20, ErrorMessage = "do dai 0-20")]
        public string Name { get; set; }
        public string Roles { get; set; }
        public int Luong { get; set; }
    }
}
