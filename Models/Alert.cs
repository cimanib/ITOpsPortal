namespace ITOpsPortal.Models;

public enum RagStatus { Green, Amber, Red }
public enum FootnoteTone { Negative, Positive }
public enum AlertSeverity { Critical, Warning }
public enum CapacityLevel { Good, High, Overloaded }

public record KpiItem(
    string Title, string Value, string Icon, string Tint,
    RagStatus Status, string Footnote, FootnoteTone Tone);

public record ProjectItem(
    string Name, string Owner, int Progress, RagStatus Status, DateOnly Due);

public record TicketBucket(string Label, int Count, string Color);

public record ServiceDeskSummary(
    IReadOnlyList<TicketBucket> Buckets, int SlaCompliance, string AvgResponse)
{
    public int Total => Buckets.Sum(b => b.Count);
}

public record Alert(string Message, string Icon, AlertSeverity Severity, string TimeAgo);

public record CapacityItem(string Employee, string Role, int Utilization, CapacityLevel Level);

public record SecuritySummary(int Score, int Critical, int High, int Medium, int Low);

public record RenewalItem(string Item, string Type, DateOnly RenewalDate, int DaysLeft);

public record DashboardData(
    string DateRange,
    IReadOnlyList<KpiItem> Kpis,
    IReadOnlyList<ProjectItem> Projects,
    ServiceDeskSummary ServiceDesk,
    IReadOnlyList<Alert> Alerts,
    IReadOnlyList<CapacityItem> Capacity,
    SecuritySummary Security,
    IReadOnlyList<RenewalItem> Renewals,
    IReadOnlyList<string> WeeklySummary);

public record UserProfile(string Name, string Initials, string Role);
