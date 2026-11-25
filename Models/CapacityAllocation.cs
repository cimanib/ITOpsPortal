using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class CapacityAllocation : Entity
{
    public string Member { get; set; } = "Michael Brown";
    public string Project { get; set; } = "IT Infrastructure Upgrade";
    [Required(ErrorMessage = "Role is required")] public string Role { get; set; } = "";
    [Range(0,200)] public int Allocation { get; set; } = 50;
    public DateTime FromDate { get; set; } = DateTime.Today;
    public DateTime ToDate { get; set; } = DateTime.Today;
    public int Available => Math.Max(0, 100 - Allocation);
    public string Status => Allocation > 100 ? "Overloaded" : Allocation >= 90 ? "Near limit" : "Healthy";
}
