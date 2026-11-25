using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class PortalSettings
{
    [Required(ErrorMessage = "Portal name is required")] public string PortalName { get; set; } = "IT Operations Portal";
    [Required(ErrorMessage = "Notification email is required"), EmailAddress] public string NotificationEmail { get; set; } = "it-managers@company.com";
    [Range(0, 100)] public int SlaCompliance { get; set; } = 94;
    public bool EmailAlerts { get; set; } = true;

    public PortalSettings Clone() => (PortalSettings)MemberwiseClone();
    public void CopyFrom(PortalSettings s) { PortalName = s.PortalName; NotificationEmail = s.NotificationEmail; SlaCompliance = s.SlaCompliance; EmailAlerts = s.EmailAlerts; }
}
