using System.Security.Claims;

namespace ITOpsPortal.Services;

public static class UserDisplay
{
    public static string Name(ClaimsPrincipal u) =>
        u.FindFirst("name")?.Value ?? u.FindFirst("preferred_username")?.Value ?? u.FindFirst("email")?.Value ?? "User";

    public static string Role(ClaimsPrincipal u) => u.FindFirst("role")?.Value ?? "";

    public static string Initials(ClaimsPrincipal u)
    {
        var parts = Name(u).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return parts.Length == 0 ? "U" : string.Concat(parts.Take(2).Select(p => char.ToUpperInvariant(p[0])));
    }
}
