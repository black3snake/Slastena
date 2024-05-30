using Microsoft.EntityFrameworkCore;
using Slastena.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(option => {
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

builder.Services.AddRazorPages();

//builder.Services.AddControllers(); // ���� ���� builder.Services.AddControllersWithViews() �� ��� API ��� ������ � ������� ����� ��������

builder.Services.AddDbContext<SlastenaPieShopDbContext>(options => { 
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:SlastenaPieShopDbContextConnection"]); 
});

// up Blazor
builder.Services.AddServerSideBlazor();

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
    sb.Append("<h1>��� �������</h1>");
    sb.Append("<table>");
    sb.Append("<tr><th>���</th><th>Lifetime</th><th>����������</th></tr>");
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

app.MapRazorPages();

// up SignalR for Blazor
app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

//app.MapControllers(); // ������ �� �����, �� ���� ���� app.MapDefaultControllerRoute() �� � ��� ���� ������ API ����� ��������

DbInitializer.Seed(app);
app.Run();
