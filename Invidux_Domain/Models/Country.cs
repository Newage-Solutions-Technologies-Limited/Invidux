using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }
    }
}
