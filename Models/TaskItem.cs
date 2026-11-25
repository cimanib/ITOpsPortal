using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class TaskItem : Entity
{
    [Required(ErrorMessage = "Task Title is required")] public string Title { get; set; } = "";
    public string Project { get; set; } = "IT Infrastructure Upgrade";
    public string Assignee { get; set; } = "Michael Brown";
    public string Priority { get; set; } = "High";
    public DateTime DueDate { get; set; } = DateTime.Today;
    public int EstimateHours { get; set; } = 0;
    public string Status { get; set; } = "Open";
}
