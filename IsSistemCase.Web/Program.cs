using IsSistemCase.Core.Models.Options;
using IsSistemCase.Core.Repositories;
using IsSistemCase.Core.Services;
using IsSistemCase.Core.UnitOfWorks;
using IsSistemCase.Repository.Contexts;
using IsSistemCase.Repository.Repositories;
using IsSistemCase.Repository.UnitOfWorks;
using IsSistemCase.Service.Mappings;
using IsSistemCase.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoy<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddAutoMapper(typeof(ReservationProfile));

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddDbContext<IsSistemSqlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(IsSistemSqlDbContext)).GetName().Name);
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var isSistemDbContext = serviceProvider.GetRequiredService<IsSistemSqlDbContext>();
    isSistemDbContext.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
