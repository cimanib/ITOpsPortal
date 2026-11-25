# IT Ops Portal – Blazor dashboard

Blazor Web App (.NET 8, Interactive Server) that recreates the IT Operations dashboard design using mock data.

## Run
```bash
dotnet run
```
Open http://localhost:5080

## Structure
- `Models/DashboardModels.cs` – records/enums for the dashboard
- `Components/Pages/Dashboard.razor` – the dashboard page
- `Components/Shared/` – `Card`, `KpiTile`, `StatusBadge`, `DonutChart`, `GaugeChart`, `Icon`
- `Components/Layout/` – `MainLayout` (top bar) and `NavMenu` (sidebar)
- `wwwroot/app.css` – styling (CSS variables at the top)

Other sidebar links open a placeholder page (`Components/Pages/Section.razor`).
To target a newer SDK, change `TargetFramework` in the `.csproj` (e.g. `net9.0`/`net10.0`).
