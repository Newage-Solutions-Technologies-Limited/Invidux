using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class Order
    {
        [Key] 
        public int Id { get; set; }
        public string OrdeyBy { get; set; }
        public string TokenCode { get; set; }
        public string TradedBy { get; set; }
        public string OrderStatus { get; set; }
        public string OrderSide { get; set; }
        public string OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal OrderVolume { get; set; }
        public decimal FilledVolume { get; set; }
        public string OrderType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
