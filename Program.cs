using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectSite.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProiectSiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectSiteContext") ?? throw new InvalidOperationException("Connection string 'ProiectSiteContext' not found.")));

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectSiteContext") ?? throw new InvalidOperationException("Connection string 'ProiectSiteContext' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options =>
//   options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()    
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddRazorPages(options =>
    {
        options.Conventions.AuthorizeFolder("/Vacations", "AdminPolicy");
        options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
        options.Conventions.AllowAnonymousToPage("/Index");
        options.Conventions.AuthorizeFolder("/Reservations");
    });  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
