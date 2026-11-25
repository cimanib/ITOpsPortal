using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class SecurityIssue : Entity
{
    [Required(ErrorMessage = "Issue Title is required")] public string Title { get; set; } = "";
    public string Severity { get; set; } = "Critical";
    public string AffectedSystem { get; set; } = "";
    public string Owner { get; set; } = "Michael Brown";
    public DateTime DetectedOn { get; set; } = DateTime.Today;
    public DateTime TargetFix { get; set; } = DateTime.Today;
    public string Status { get; set; } = "Open";
}
