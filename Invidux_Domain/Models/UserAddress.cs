using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class UserAddress: BaseUser
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
