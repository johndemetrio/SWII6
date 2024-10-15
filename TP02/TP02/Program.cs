using Microsoft.EntityFrameworkCore;
using TP02.Data; // Namespace do ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TP02DbContext>(options =>
    options.UseSqlite("Data Source=tp02.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
