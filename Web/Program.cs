using Domain.Interfaces;
using Infrastructure.Data;
using Web.Abstractions.Interfaces;
using Web.Interfaces;
using Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'WebIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<IdentityDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityDbContext>();

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<CustomTMDBLibClient>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICreditsSearchService, SearchService>();
builder.Services.AddScoped<IMovieSearchService, SearchService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IMoviePreviewModelService, MoviePreviewModelService>();
builder.Services.AddScoped<IUriComposer, UriComposer>();
builder.Services.AddScoped<IMovieDetailsViewModelService, MovieDetailsViewModelService>();

Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);


/*builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<IdentityDbContext>();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});*/


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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
