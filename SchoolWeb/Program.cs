using Dal;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.Middlewares;
using SchoolWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IInformationService, InformationService>();
builder.Services.AddWebOptimizer();
builder.Services.AddDbContext<SchoolContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolDatabase")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseWebOptimizer();
app.UseStaticFiles();

app.UseSchoolFiles(app.Environment.ContentRootPath);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "teacher_index_route",
    pattern: "Prof",
    defaults: new { Controller = "Teacher", Action = "Index" });

app.MapControllerRoute(
    name: "teacher_details_route",
    pattern: "Prof/{id?}",
    defaults: new { Controller = "Teacher", Action = "Details" });

app.Run();
