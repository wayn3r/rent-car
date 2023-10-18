using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentCar.Database;
using RentCar.Database.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RentCarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentCarConnection"))
);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<RentCarContext>()
    .AddDefaultTokenProviders();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Pages/Unauthorized";
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RentCarContext>();
    context.Database.Migrate();

   
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    // Verifica si el usuario ya existe
    var existingUser = userManager.FindByEmailAsync("admin@admin.com").Result;

    if (existingUser == null)
    {
        // El usuario no existe, así que lo creamos
        var newUser = new User
        {
            UserName = "admin",
            Email = "admin@admin.com",
           
        };

        var result = userManager.CreateAsync(newUser, "@Admin1234").Result;

        if (result.Succeeded)
        {
            // Usuario creado exitosamente
            userManager.AddToRoleAsync(newUser, "Admin").Wait();
            Console.WriteLine("Usuario creado exitosamente.");
        }
        else
        {
            Console.WriteLine("Error al crear el usuario:");
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
        }
    }
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

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
