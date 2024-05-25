using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ������.Reposytory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICar, SqlCar>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	try
	{
		var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		dbContext.Database.Migrate();
	}
	catch (Exception ex)
	{
		var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred while seeding initial data");
	}
}

app.Run();
