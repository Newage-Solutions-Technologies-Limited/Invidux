using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }
        public string? UserId { get; set; } // ID of the user who performed the action
        public string? Action { get; set; } // Description of the action (e.g., "Updated Profile", "Deleted Transaction")
        public string? TableName { get; set; } // Affected table or entity
        public string? RecordId { get; set; } // ID of the affected record
        public string? OldValues { get; set; } // State of the data before change (JSON format)
        public string? NewValues { get; set; } // State of the data after change (JSON format)
        public DateTime Timestamp { get; set; } // When the action was performed
        public string? AdditionalInformation { get; set; } // Any additional information
    }


}
