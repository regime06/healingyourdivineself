using HealingDivineSelf.Components;
using HealingDivineSelf.Services.WorkshopService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IWorkshopsService,WorkshopsService>();


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
