using System.Security.Claims;
using ITOpsPortal.Components;
using ITOpsPortal.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();

// ---- Sign-in with Microsoft Entra ID (OpenID Connect, authorization code + PKCE) ----
var mantra = builder.Configuration.GetSection("MantraId");
if (string.IsNullOrWhiteSpace(mantra["Authority"]) || string.IsNullOrWhiteSpace(mantra["ClientId"]))
    throw new InvalidOperationException("Configure MantraId:Authority and MantraId:ClientId (and ClientSecret via user-secrets).");

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;   // visitors go to OUR /login page
})
    .AddCookie(o =>
    {
        o.LoginPath = "/login";
        o.ReturnUrlParameter = "returnUrl";
        o.Cookie.Name = "itops.auth";
        o.Cookie.HttpOnly = true;
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        o.Cookie.SameSite = SameSiteMode.Lax;
        o.ExpireTimeSpan = TimeSpan.FromMinutes(mantra.GetValue("SessionMinutes", 2));   // 2 min = testing; raise later (e.g. 60)
        o.SlidingExpiration = false;
    })
    .AddOpenIdConnect(o =>
    {
        o.Authority = mantra["Authority"];
        o.ClientId = mantra["ClientId"];
        o.ClientSecret = mantra["ClientSecret"];
        o.ResponseType = "code";
        o.UsePkce = true;
        o.SaveTokens = false;
        o.GetClaimsFromUserInfoEndpoint = false;      // must be false for Entra (token is issued for your API)
        o.MapInboundClaims = false;
        o.CallbackPath = "/signin-oidc";
        o.SignedOutCallbackPath = "/signout-callback-oidc";
        o.SignedOutRedirectUri = "/login?signedout=1";
        o.Scope.Clear();
        foreach (var s in mantra.GetSection("Scopes").Get<string[]>() ?? new[] { "openid", "profile", "email" }) o.Scope.Add(s);
        o.TokenValidationParameters.NameClaimType = "name";
        o.TokenValidationParameters.RoleClaimType = "role";
        o.Events.OnTokenValidated = ctx =>
        {
            if (ctx.Principal?.Identity is ClaimsIdentity id && ctx.TokenEndpointResponse is { } t)
            {
                id.AddClaim(new Claim("access_token", t.AccessToken));
                if (long.TryParse(t.ExpiresIn, out var secs))
                    id.AddClaim(new Claim("expires_at", DateTimeOffset.UtcNow.AddSeconds(secs).ToUnixTimeSeconds().ToString()));
            }
            return Task.CompletedTask;
        };
        o.Events.OnRedirectToIdentityProvider = ctx =>
        {
            // Always show Microsoft's "Pick an account" screen. Remove this block to skip it when already signed in.
            if (ctx.ProtocolMessage.RequestType == OpenIdConnectRequestType.Authentication)
                ctx.ProtocolMessage.Prompt = "select_account";
            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization(o => o.FallbackPolicy =
    new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());

// ---- API client ----
var apiBase = builder.Configuration["Api:BaseUrl"] ?? throw new InvalidOperationException("Configure Api:BaseUrl in appsettings.json.");
builder.Services.AddHttpClient<PortalApiClient>(c => c.BaseAddress = new Uri(apiBase.TrimEnd('/') + "/"));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// Our own login page. The button on it goes to /auth/login, which goes to Microsoft.
app.MapGet("/login", (HttpContext ctx, string? returnUrl, string? signedout) =>
{
    var back = LocalUrl(returnUrl);
    if (ctx.User.Identity?.IsAuthenticated == true) return Results.Redirect(back);
    return Results.Content(LoginPage.Render(back, signedout is not null), "text/html");
}).AllowAnonymous();

app.MapGet("/auth/login", (string? returnUrl) =>
    Results.Challenge(new AuthenticationProperties { RedirectUri = LocalUrl(returnUrl) }, new[] { OpenIdConnectDefaults.AuthenticationScheme }))
    .AllowAnonymous();

app.MapGet("/auth/logout", () =>
    Results.SignOut(new AuthenticationProperties { RedirectUri = "/login?signedout=1" },
        new[] { CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme }));

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();

// Only allow local return URLs (prevents open-redirect).
static string LocalUrl(string? url) =>
    !string.IsNullOrEmpty(url) && url.StartsWith('/') && !url.StartsWith("//") && !url.StartsWith("/\\") ? url : "/";
