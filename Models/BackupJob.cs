using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class BackupJob : Entity
{
    [Required(ErrorMessage = "Job Name is required")] public string JobName { get; set; } = "";
    public string Source { get; set; } = "Core Servers";
    public string Destination { get; set; } = "Offsite Cloud Storage";
    public string Frequency { get; set; } = "Hourly";
    public int RetentionDays { get; set; } = 30;
    public string Encryption { get; set; } = "AES-256";
    public DateTime LastRun { get; set; } = DateTime.Now;
    public int SizeGb { get; set; } = 0;
    public string Status { get; set; } = "Scheduled";
}
