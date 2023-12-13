﻿using System.ComponentModel.DataAnnotations;
using Invidux_Domain.Utilities;

namespace Invidux_Domain.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public string TransactionRef { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Flow { get; set; }
        public string Amount { get; set; }
        public string CurrencySymbol { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
