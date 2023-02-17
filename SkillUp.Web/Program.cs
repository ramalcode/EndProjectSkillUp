using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SkillUp.DAL.Context;
using SkillUp.DAL.Extension;
using SkillUp.Entity.Entities;
using SkillUp.Service.Extensions;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
// Add services to the container.
builder.Services.AddControllersWithViews();

StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("Stripe:SecretKey");

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 6;
    opt.Lockout.AllowedForNewUsers = true;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentityCore<Instructor>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 6;
    opt.Lockout.AllowedForNewUsers = true;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();