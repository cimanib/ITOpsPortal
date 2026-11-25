using System.ComponentModel.DataAnnotations;

namespace ITOpsPortal.Models;

public class AppUser : Entity
{
    [Required(ErrorMessage = "Full Name is required")] public string FullName { get; set; } = "";
    [Required(ErrorMessage = "Email is required")] [EmailAddress] public string Email { get; set; } = "";
    public string Role { get; set; } = "IT Manager";
    public string Department { get; set; } = "IT Operations";
    public string AccessLevel { get; set; } = "Admin";
    public string Status { get; set; } = "Active";
}
