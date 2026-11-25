
using ITOpsPortal.Models;

namespace ItOpsPortal.Services;

public static class SeedData
{
    public static List<Project> Projects => new()
    {
        new() { Name = "IT Infrastructure Upgrade", Owner = "Michael Brown", StartDate = new DateTime(2025, 3, 1), TargetDate = new DateTime(2025, 6, 30), Status = "On Track", Progress = 65, Budget = 1800000m },
        new() { Name = "Cloud Migration", Owner = "Sarah Johnson", StartDate = new DateTime(2025, 3, 15), TargetDate = new DateTime(2025, 9, 30), Status = "At Risk", Progress = 40, Budget = 1200000m },
        new() { Name = "Security Enhancement", Owner = "David Wilson", StartDate = new DateTime(2025, 2, 1), TargetDate = new DateTime(2025, 6, 15), Status = "On Track", Progress = 80, Budget = 750000m },
        new() { Name = "Digital Workplace", Owner = "Lisa Taylor", StartDate = new DateTime(2025, 5, 1), TargetDate = new DateTime(2025, 12, 31), Status = "Delayed", Progress = 20, Budget = 950000m },
    };

    public static List<TaskItem> TaskItems => new()
    {
        new() { Title = "Patch core switches", Project = "IT Infrastructure Upgrade", Assignee = "David Wilson", Priority = "High", DueDate = new DateTime(2025, 5, 30), EstimateHours = 12, Status = "In Progress" },
        new() { Title = "Migrate mailboxes", Project = "Cloud Migration", Assignee = "Sarah Johnson", Priority = "Medium", DueDate = new DateTime(2025, 6, 6), EstimateHours = 24, Status = "Open" },
        new() { Title = "Update firewall rules", Project = "Security Enhancement", Assignee = "Michael Brown", Priority = "High", DueDate = new DateTime(2025, 6, 2), EstimateHours = 8, Status = "Open" },
        new() { Title = "Document backups", Project = "Digital Workplace", Assignee = "Lisa Taylor", Priority = "Low", DueDate = new DateTime(2025, 5, 15), EstimateHours = 4, Status = "Done" },
    };

    public static List<CapacityAllocation> CapacityAllocations => new()
    {
        new() { Member = "John Smith", Project = "Cloud Migration", Role = "Network Engineer", Allocation = 120, FromDate = new DateTime(2025, 5, 19), ToDate = new DateTime(2025, 5, 25) },
        new() { Member = "Sarah Johnson", Project = "Cloud Migration", Role = "Cloud Architect", Allocation = 95, FromDate = new DateTime(2025, 5, 19), ToDate = new DateTime(2025, 5, 25) },
        new() { Member = "David Wilson", Project = "Security Enhancement", Role = "Security Lead", Allocation = 110, FromDate = new DateTime(2025, 5, 19), ToDate = new DateTime(2025, 5, 25) },
        new() { Member = "Lisa Taylor", Project = "Digital Workplace", Role = "Analyst", Allocation = 70, FromDate = new DateTime(2025, 5, 19), ToDate = new DateTime(2025, 5, 25) },
    };

    public static List<ServiceRequest> ServiceRequests => new()
    {
        new() { Reference = "SR-2025-1042", Description = "VPN access issue", Priority = "High", AssignedTo = "David Wilson", Category = "Network", Status = "Open", DueDate = new DateTime(2025, 5, 26) },
        new() { Reference = "SR-2025-1041", Description = "Email not syncing", Priority = "Medium", AssignedTo = "Sarah Johnson", Category = "Software", Status = "In Progress", DueDate = new DateTime(2025, 5, 25) },
        new() { Reference = "SR-2025-1039", Description = "New user setup", Priority = "Low", AssignedTo = "Michael Brown", Category = "Access", Status = "Resolved", DueDate = new DateTime(2025, 5, 20) },
        new() { Reference = "SR-2025-1038", Description = "Laptop replacement", Priority = "Medium", AssignedTo = "Lisa Taylor", Category = "Hardware", Status = "Open", DueDate = new DateTime(2025, 5, 24) },
        new() { Reference = "SR-2025-1037", Description = "Software installation", Priority = "Low", AssignedTo = "David Wilson", Category = "Software", Status = "Closed", DueDate = new DateTime(2025, 5, 18) },
    };

    public static List<SecurityIssue> SecurityIssues => new()
    {
        new() { Title = "Unpatched VPN gateway", Severity = "Critical", AffectedSystem = "VPN Gateway", Owner = "David Wilson", DetectedOn = new DateTime(2025, 5, 21), TargetFix = new DateTime(2025, 5, 24), Status = "Open" },
        new() { Title = "Expired TLS certificate", Severity = "Critical", AffectedSystem = "Web Proxy", Owner = "Michael Brown", DetectedOn = new DateTime(2025, 5, 22), TargetFix = new DateTime(2025, 5, 25), Status = "Open" },
        new() { Title = "Weak admin passwords", Severity = "Critical", AffectedSystem = "Active Directory", Owner = "Lisa Taylor", DetectedOn = new DateTime(2025, 5, 20), TargetFix = new DateTime(2025, 5, 27), Status = "In Progress" },
        new() { Title = "Outdated antivirus", Severity = "Low", AffectedSystem = "Endpoints", Owner = "Sarah Johnson", DetectedOn = new DateTime(2025, 5, 10), TargetFix = new DateTime(2025, 5, 17), Status = "Resolved" },
    };

    public static List<Renewal> Renewals => new()
    {
        new() { Item = "Microsoft 365 Licences", Type = "Licence", Vendor = "Microsoft", RenewalDate = DateTime.Today.AddDays(25), AnnualCost = 480000m, Owner = "Lisa Taylor" },
        new() { Item = "Firewall support", Type = "Support", Vendor = "Fortinet", RenewalDate = DateTime.Today.AddDays(28), AnnualCost = 260000m, Owner = "Michael Brown" },
        new() { Item = "Backup service", Type = "Subscription", Vendor = "Veeam", RenewalDate = DateTime.Today.AddDays(62), AnnualCost = 310000m, Owner = "David Wilson" },
        new() { Item = "Domain names", Type = "Domain", Vendor = "Afrihost", RenewalDate = DateTime.Today.AddDays(75), AnnualCost = 18000m, Owner = "Sarah Johnson" },
    };

    public static List<ReportRecord> ReportRecords => new()
    {
        new() { ReportType = "Service Desk Summary", DateFrom = new DateTime(2025, 5, 19), DateTo = new DateTime(2025, 5, 25), Format = "PDF", Recipients = "it-managers@company.com", Schedule = "Weekly", GeneratedBy = "Jane Smith", GeneratedOn = new DateTime(2025, 5, 25) },
        new() { ReportType = "Project Status", DateFrom = new DateTime(2025, 5, 12), DateTo = new DateTime(2025, 5, 18), Format = "XLSX", Recipients = "it-managers@company.com", Schedule = "Monthly", GeneratedBy = "Jane Smith", GeneratedOn = new DateTime(2025, 5, 18) },
        new() { ReportType = "Security Review", DateFrom = new DateTime(2025, 5, 5), DateTo = new DateTime(2025, 5, 11), Format = "PDF", Recipients = "security@company.com", Schedule = "Once", GeneratedBy = "David Wilson", GeneratedOn = new DateTime(2025, 5, 11) },
        new() { ReportType = "Capacity Plan", DateFrom = new DateTime(2025, 4, 28), DateTo = new DateTime(2025, 5, 4), Format = "PDF", Recipients = "it-managers@company.com", Schedule = "Once", GeneratedBy = "Jane Smith", GeneratedOn = new DateTime(2025, 5, 4) },
    };

    public static List<AlertItem> AlertItems => new()
    {
        new() { Title = "Project Phoenix is 14 days behind schedule", Severity = "High", Trigger = "Project delay", NotifyGroup = "Project Leads", Channel = "Email and in-app", Status = "New", RaisedOn = DateTime.Now.AddMinutes(-10) },
        new() { Title = "3 critical security issues require attention", Severity = "Critical", Trigger = "Security issue", NotifyGroup = "Security Team", Channel = "Email and in-app", Status = "New", RaisedOn = DateTime.Now.AddMinutes(-25) },
        new() { Title = "John Smith is over allocated (120%)", Severity = "Medium", Trigger = "Over-allocation", NotifyGroup = "IT Managers", Channel = "In-app", Status = "Seen", RaisedOn = DateTime.Now.AddHours(-1) },
        new() { Title = "2 renewals expiring within 30 days", Severity = "Low", Trigger = "Renewal expiry", NotifyGroup = "IT Managers", Channel = "Email", Status = "Seen", RaisedOn = DateTime.Now.AddHours(-2) },
    };

    public static List<AppUser> AppUsers => new()
    {
        new() { FullName = "Jane Smith", Email = "jane.smith@company.com", Role = "IT Manager", Department = "IT Operations", AccessLevel = "Admin", Status = "Active" },
        new() { FullName = "Michael Brown", Email = "michael.brown@company.com", Role = "Project Lead", Department = "Infrastructure", AccessLevel = "Editor", Status = "Active" },
        new() { FullName = "Sarah Johnson", Email = "sarah.johnson@company.com", Role = "Engineer", Department = "Cloud", AccessLevel = "Editor", Status = "Active" },
        new() { FullName = "Lisa Taylor", Email = "lisa.taylor@company.com", Role = "Analyst", Department = "Workplace", AccessLevel = "Viewer", Status = "Inactive" },
    };

    public static List<BackupJob> BackupJobs => new()
    {
        new() { JobName = "Nightly Server Backup", Source = "Core Servers", Destination = "Offsite Cloud Storage", Frequency = "Daily at 02:00", RetentionDays = 30, Encryption = "AES-256", LastRun = DateTime.Now.AddHours(-8), SizeGb = 1800, Status = "Success" },
        new() { JobName = "Database snapshot", Source = "Databases", Destination = "Local Repository", Frequency = "Hourly", RetentionDays = 14, Encryption = "AES-256", LastRun = DateTime.Now.AddHours(-9), SizeGb = 640, Status = "Success" },
        new() { JobName = "File shares", Source = "File Shares", Destination = "Immutable Archive", Frequency = "Daily at 23:00", RetentionDays = 90, Encryption = "AES-256", LastRun = DateTime.Now.AddHours(-11), SizeGb = 2300, Status = "Warning" },
        new() { JobName = "Email archive", Source = "Email Archive", Destination = "Offsite Cloud Storage", Frequency = "Weekly", RetentionDays = 60, Encryption = "AES-128", LastRun = DateTime.Now.AddHours(-12), SizeGb = 0, Status = "Failed" },
    };

}
