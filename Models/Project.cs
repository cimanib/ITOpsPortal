using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class Project : Entity
{
    [Required(ErrorMessage = "Project Name is required")] public string Name { get; set; } = "";
    public string Owner { get; set; } = "Michael Brown";
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime TargetDate { get; set; } = DateTime.Today;
    public string Status { get; set; } = "On Track";
    [Range(0,100)] public int Progress { get; set; } = 0;
    public decimal Budget { get; set; } = 0;
}
