using GestorDeMembresia.UI.Services;
using GestorDeMembresia.UI.Config;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de ApiSettings desde appsettings.json
builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

// Registro de ApiService con HttpClient y ApiSettings
builder.Services.AddHttpClient<ApiService>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
    client.DefaultRequestHeaders.Add("apiKey", settings.ApiKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta inicial: Membresias/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Membresias}/{action=Index}/{id?}");

app.Run();

