using ITOpsPortal.Models;

namespace ITOpsPortal.Services;

/// <summary>Single place that maps each model to its API resource path.</summary>
public static class ApiRoutes
{
    private static readonly Dictionary<Type, string> Map = new()
    {
        [typeof(Project)] = "api/projects",
        [typeof(TaskItem)] = "api/tasks",
        [typeof(CapacityAllocation)] = "api/capacity",
        [typeof(ServiceRequest)] = "api/service-desk",
        [typeof(SecurityIssue)] = "api/security",
        [typeof(Renewal)] = "api/renewals",
        [typeof(ReportRecord)] = "api/reports",
        [typeof(AlertItem)] = "api/alerts",
        [typeof(AppUser)] = "api/users",
        [typeof(BackupJob)] = "api/security/backup",
    };

    public const string Settings = "api/settings";
    public const string Dashboard = "api/dashboard";

    public static string For<T>() =>
        Map.TryGetValue(typeof(T), out var route) ? route : throw new InvalidOperationException($"No API route is registered for {typeof(T).Name}.");
}
