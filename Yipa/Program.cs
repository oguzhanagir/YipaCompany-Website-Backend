using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
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

//Businees Classes
builder.Services.AddScoped<AboutManager>();
builder.Services.AddScoped<AuthManager>();
builder.Services.AddScoped<BlogManager>();
builder.Services.AddScoped<CategoryManager>();
builder.Services.AddScoped<CommentManager>();
builder.Services.AddScoped<ContactManager>();
builder.Services.AddScoped<NewsletterManager>();
builder.Services.AddScoped<RoleManager>();
builder.Services.AddScoped<SocialMediaManager>();
builder.Services.AddScoped<UserManager>();



//Fluent Validation
builder.Services.AddTransient<IValidator<About>, AboutValidation>();
builder.Services.AddTransient<IValidator<Blog>, BlogValidation>();
builder.Services.AddTransient<IValidator<Comment>, CommentValidation>();
builder.Services.AddTransient<IValidator<Contact>, ContactValidation>();
builder.Services.AddTransient<IValidator<Newsletter>, NewsletterValidation>();
builder.Services.AddTransient<IValidator<Role>, RoleValidation>();
builder.Services.AddTransient<IValidator<SocialMedia>, SocialMediaValidation>();
builder.Services.AddTransient<IValidator<User>, UserValdiation>();
builder.Services.AddTransient<IValidator<Category>, CategoryValidation>();





builder.Services.AddHttpContextAccessor();


builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
{
    options.LoginPath = "/Auth/Login";
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
