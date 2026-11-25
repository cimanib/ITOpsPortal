namespace ITOpsPortal.Services;

/// <summary>HTML for the sign-in page. Styling comes from the .login-* classes in wwwroot/app.css.</summary>
public static class LoginPage
{
    private const string Logo = "<svg width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" aria-hidden=\"true\"><rect x=\"2\" y=\"3\" width=\"20\" height=\"14\" rx=\"2\"/><line x1=\"8\" y1=\"21\" x2=\"16\" y2=\"21\"/><line x1=\"12\" y1=\"17\" x2=\"12\" y2=\"21\"/></svg>";
    private const string Microsoft = "<svg width=\"20\" height=\"20\" viewBox=\"0 0 21 21\" aria-hidden=\"true\"><rect x=\"1\" y=\"1\" width=\"9\" height=\"9\" fill=\"#f25022\"/><rect x=\"11\" y=\"1\" width=\"9\" height=\"9\" fill=\"#7fba00\"/><rect x=\"1\" y=\"11\" width=\"9\" height=\"9\" fill=\"#00a4ef\"/><rect x=\"11\" y=\"11\" width=\"9\" height=\"9\" fill=\"#ffb900\"/></svg>";

    public static string Render(string returnUrl, bool signedOut)
    {
        var notice = signedOut ? "<p class=\"login-ok\" role=\"status\">You have signed out.</p>" : "";
        var href = "/auth/login?returnUrl=" + Uri.EscapeDataString(returnUrl);
        return $$"""
<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Sign in - IT Ops Portal</title>
  <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet" />
  <link rel="stylesheet" href="/app.css" />
</head>
<body class="login-bg">
  <main class="login-card">
    <div class="login-brand"><span class="login-logo">{{Logo}}</span><span>IT Ops Portal</span></div>
    <h1>Welcome back</h1>
    <p class="login-sub">Sign in with your work account to continue.</p>
    {{notice}}
    <a class="login-ms" href="{{href}}">{{Microsoft}} Sign in with Microsoft</a>
    <p class="login-foot">Access is limited to authorised staff.</p>
  </main>
</body>
</html>
""";
    }
}
