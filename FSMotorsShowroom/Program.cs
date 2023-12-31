using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FSMotorsShowroom.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<FSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDefaultIdentity<IdentityUser>()
//                    .AddEntityFrameworkStores<FSDbContext>().AddDefaultTokenProviders().AddDefaultUI();
builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders().AddRoles<IdentityRole>().AddEntityFrameworkStores<FSDbContext>();
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<FSDbContext>();


//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<FSDbContext>()
//    .AddDefaultTokenProviders();
//builder.Services.AddDefaultIdentity<User>().AddDefaultTokenProviders()
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<FSDbContext>();
//builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders() (options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FSDbContext>();
builder.Services.AddRazorPages();
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
    name: "identity",
    areaName: "Identity",
    pattern: "Identity/{controller=Account}/{action=Login}/{id?}");
app.MapRazorPages();
app.Run();
