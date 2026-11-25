using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using ITOpsPortal.Models;
using ITOpsPortal.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Polly;

namespace ITOpsPortal.Services;


public class PortalApiClient(HttpClient http, AuthenticationStateProvider auth)
{
    public async Task<List<T>> ListAsync<T>(CancellationToken ct = default) where T : Entity
    {
        using var res = await SendAsync(() => http.GetAsync(ApiRoutes.For<T>(), ct), ct);
        return await res.Content.ReadFromJsonAsync<List<T>>(ct) ?? new();
    }

    public async Task<T> CreateAsync<T>(T item, CancellationToken ct = default) where T : Entity
    {
        using var res = await SendAsync(() => http.PostAsJsonAsync(ApiRoutes.For<T>(), item, ct), ct);
        return (await res.Content.ReadFromJsonAsync<T>(ct))!;
    }

    public async Task UpdateAsync<T>(T item, CancellationToken ct = default) where T : Entity
    {
        using var res = await SendAsync(() => http.PutAsJsonAsync($"{ApiRoutes.For<T>()}/{item.Id}", item, ct), ct);
    }

    public async Task DeleteAsync<T>(int id, CancellationToken ct = default) where T : Entity
    {
        using var res = await SendAsync(() => http.DeleteAsync($"{ApiRoutes.For<T>()}/{id}", ct), ct);
    }

    public async Task<PortalSettings> GetSettingsAsync(CancellationToken ct = default)
    {
        using var res = await SendAsync(() => http.GetAsync(ApiRoutes.Settings, ct), ct);
        return await res.Content.ReadFromJsonAsync<PortalSettings>(ct) ?? new();
    }

    public async Task<PortalSettings> SaveSettingsAsync(PortalSettings settings, CancellationToken ct = default)
    {
        using var res = await SendAsync(() => http.PutAsJsonAsync(ApiRoutes.Settings, settings, ct), ct);
        return await res.Content.ReadFromJsonAsync<PortalSettings>(ct) ?? settings;
    }

    public async Task<DashboardSummary> GetDashboardAsync(CancellationToken ct = default)
    {
        using var res = await SendAsync(() => http.GetAsync(ApiRoutes.Dashboard, ct), ct);
        return (await res.Content.ReadFromJsonAsync<DashboardSummary>(ct))!;
    }

    /// <summary>Adds the signed-in user's access token (issued by Mantra ID) to outgoing requests.</summary>
    private async Task AttachTokenAsync()
    {
        var user = (await auth.GetAuthenticationStateAsync()).User;
        var token = user.FindFirst("access_token")?.Value;
        var expiry = user.FindFirst("expires_at")?.Value;
        if (token is null || (long.TryParse(expiry, out var e) && DateTimeOffset.FromUnixTimeSeconds(e) <= DateTimeOffset.UtcNow.AddSeconds(30)))
            throw new ApiException("Your session has expired. Please sign in again.", HttpStatusCode.Unauthorized);
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }

    private async Task<HttpResponseMessage> SendAsync(Func<Task<HttpResponseMessage>> call, CancellationToken ct)
    {
        await AttachTokenAsync();
        HttpResponseMessage res;
        try { res = await call(); }
        catch (Exception ex) when (ex is HttpRequestException or ExecutionRejectedException
                                   || (ex is OperationCanceledException && !ct.IsCancellationRequested))
        {
            throw new ApiException("Cannot reach the API right now. Check that it is running and try again.", null, ex);
        }

        if (res.IsSuccessStatusCode) return res;
        var message = res.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden
            ? "You are not authorised for this action, or your session has expired. Please sign in again."
            : await ReadErrorAsync(res);
        var status = res.StatusCode;
        res.Dispose();
        throw new ApiException(message, status);
    }

    private static async Task<string> ReadErrorAsync(HttpResponseMessage res)
    {
        try
        {
            using var doc = JsonDocument.Parse(await res.Content.ReadAsStringAsync());
            var root = doc.RootElement;
            if (root.TryGetProperty("error", out var e) && e.ValueKind == JsonValueKind.String) return e.GetString()!;
            if (root.TryGetProperty("errors", out var errs) && errs.ValueKind == JsonValueKind.Object)
            {
                var first = errs.EnumerateObject().SelectMany(p => p.Value.EnumerateArray()).Select(v => v.GetString()).FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
                if (first is not null) return first;
            }
            if (root.TryGetProperty("title", out var t) && t.ValueKind == JsonValueKind.String) return t.GetString()!;
        }
        catch (JsonException) { }
        return $"The request failed ({(int)res.StatusCode} {res.ReasonPhrase}).";
    }
}
