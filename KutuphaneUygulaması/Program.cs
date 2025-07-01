var builder = WebApplication.CreateBuilder(args);

// 1. MVC servisleri ekleniyor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. Ortak middleware'ler
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();             // wwwroot içeriğini sun

app.UseRouting();

// 3. Varsayılan routing ayarı
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
