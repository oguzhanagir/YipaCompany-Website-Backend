using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Yipa.Business.Concrete;
using Yipa.Business.Validation.FluentValidation;
using Yipa.Core.Abstract;
using Yipa.DataAccess.Concrete;
using Yipa.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<YipaDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<AboutManager>();
builder.Services.AddScoped<BlogManager>();


builder.Services.AddTransient<IValidator<Blog>, BlogValidation>();






builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
});



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
