using Microsoft.EntityFrameworkCore;
using RentCar.Database;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RentCarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentCarConnection"))
);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RentCarContext>();
    context.Database.Migrate();
}

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

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
