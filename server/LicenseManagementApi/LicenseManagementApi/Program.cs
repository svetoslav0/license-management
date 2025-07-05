using LicenseManagementApi.Database.EF;
using LicenseManagementApi.Database.EF.Models;
using LicenseManagementApi.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddScoped<UserUnitOfWork>();

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    DatabaseContext databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    databaseContext.Database.Migrate();

    if (!databaseContext.SubscriptionPlans.Any())
    {
        databaseContext.SubscriptionPlans.AddRange(
            new SubscriptionPlan { Id = 1, Name = "basic", SeatLimit = 5 },
            new SubscriptionPlan { Id = 2, Name = "pro", SeatLimit = 25 },
            new SubscriptionPlan { Id = 3, Name = "enterprise", SeatLimit = 100 }
        );
    }

    databaseContext.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
