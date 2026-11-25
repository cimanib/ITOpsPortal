namespace ITOpsPortal.Models;

public record DashboardSummary(
    int Health, int Projects, int ProjectsAtRisk,
    int ServiceDeskTotal, int Open, int InProgress, int OnHold, int Resolved,
    int CriticalIssues, int Overloaded, int RenewalsExpiring, int UnreadAlerts, int SlaCompliance);
