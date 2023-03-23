using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeashellMuseumWeb.Models
{
    public class Seashell
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CommonName { get; set; }
        [DisplayName("Common Name")]
        public string Ocean { get; set; }
        public int MaxSize { get; set; }
        public string Variety { get; set; }
    }
}
