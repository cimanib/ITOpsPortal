namespace ItOpsPortal.Services;

public static class Fmt
{
    public static string Ago(DateTime t)
    {
        var d = DateTime.Now - t;
        if (d.TotalMinutes < 60) return $"{Math.Max(1, (int)d.TotalMinutes)} min ago";
        if (d.TotalHours < 24) return $"{(int)d.TotalHours} hour(s) ago";
        return $"{(int)d.TotalDays} day(s) ago";
    }
}
