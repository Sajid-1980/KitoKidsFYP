using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KitoKidsFYP.Data;
using KitoKidsFYP.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using KitoKidsFYP.CommonHelper;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("KitoKidsFYPContextConnection") ?? throw new InvalidOperationException("Connection string 'KitoKidsFYPContextConnection' not found.");

builder.Services.AddDbContext<KitoKidsFYPContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<KitoKidsFYPContext>();

 ;

// Add services to the container.
builder.Services.AddControllersWithViews();



//Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IEmailSender, EmailSender>();



builder.Services.AddControllersWithViews().AddRazorPagesOptions(options => {
    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
});



//Models Scoped Define
builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.Models.ClusterFruitLevel1>();
builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.Models.ToysLevel1>();
builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.Models.AlphaLevel1>();
builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.Models.ClusterFruitLevel2>();


builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.ViewModels.ClusterFruitLevel1ViewModel>();
builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.ViewModels.ToyLevel1ViewModel>();
builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.ViewModels.AlphaLevel1ViewModel>();
builder.Services.AddScoped<KitoKidsFYP.Areas.Admin.ViewModels.ClusterFruitLevel2ViewModel>();

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
app.UseAuthentication(); ;

app.UseAuthorization();

//app.MapControllerRoute(name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "MyArea",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();
app.Run();