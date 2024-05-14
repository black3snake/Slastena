using Microsoft.EntityFrameworkCore;
using Slastena.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SlastenaPieShopDbContext>(options => { 
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:SlastenaPieShopDbContextConnection"]); 
});

var services = builder.Services;

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute(); // "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


/*app.Run(async context =>
{
    var sb = new StringBuilder();
    sb.Append("<h1>Все сервисы</h1>");
    sb.Append("<table>");
    sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
    foreach (var svc in services)
    {
        sb.Append("<tr>");
        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        sb.Append($"<td>{svc.Lifetime}</td>");
        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
        sb.Append("</tr>");
    }
    sb.Append("</table>");
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());
});*/


DbInitializer.Seed(app);
app.Run();
