using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class Renewal : Entity
{
    [Required(ErrorMessage = "Item is required")] public string Item { get; set; } = "";
    public string Type { get; set; } = "Licence";
    public string Vendor { get; set; } = "";
    public DateTime RenewalDate { get; set; } = DateTime.Today;
    public decimal AnnualCost { get; set; } = 0;
    public string Owner { get; set; } = "Michael Brown";
    public int DaysLeft => (RenewalDate.Date - DateTime.Today).Days;
    public string Status => DaysLeft <= 30 ? "Expiring soon" : "Scheduled";
}
