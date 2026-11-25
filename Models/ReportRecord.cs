using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class ReportRecord : Entity
{
    public string ReportType { get; set; } = "Service Desk Summary";
    public DateTime DateFrom { get; set; } = DateTime.Today;
    public DateTime DateTo { get; set; } = DateTime.Today;
    public string Format { get; set; } = "PDF";
    [Required(ErrorMessage = "Recipients is required")] public string Recipients { get; set; } = "";
    public string Schedule { get; set; } = "Once";
    public string GeneratedBy { get; set; } = "Jane Smith";
    public DateTime GeneratedOn { get; set; } = DateTime.Today;
}
