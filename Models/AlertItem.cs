using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class AlertItem : Entity
{
    [Required(ErrorMessage = "Alert Title is required")] public string Title { get; set; } = "";
    public string Severity { get; set; } = "Critical";
    public string Trigger { get; set; } = "Project delay";
    public string NotifyGroup { get; set; } = "IT Managers";
    public string Channel { get; set; } = "Email and in-app";
    public string Status { get; set; } = "New";
    public DateTime RaisedOn { get; set; } = DateTime.Now;
}
