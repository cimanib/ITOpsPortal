using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class ServiceRequest : Entity
{
    [Required(ErrorMessage = "Request Reference is required")] public string Reference { get; set; } = "";
    [Required(ErrorMessage = "Description is required")] public string Description { get; set; } = "";
    public string Priority { get; set; } = "High";
    public string AssignedTo { get; set; } = "Michael Brown";
    public string Category { get; set; } = "Network";
    public string Status { get; set; } = "Open";
    public DateTime DueDate { get; set; } = DateTime.Today;
}
