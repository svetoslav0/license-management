using LicenseManagementApi.Database.EF;
using LicenseManagementApi.Database.EF.Models;
using LicenseManagementApi.Interfaces;
using LicenseManagementApi.ResponseBuilders;
using LicenseManagementApi.Services;
using LicenseManagementApi.UnitsOfWork;
using LicenseManagementApi.Validators;

using Microsoft.EntityFrameworkCore;

// TODO: Add exception handler

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
builder.Services.AddScoped<IPlanUnitOfWork, PlanUnitOfWork>();
builder.Services.AddScoped<IUserValidator, UserValidator>();
builder.Services.AddScoped<IPlanValidator, PlanValidator>();

builder.Services.AddSingleton<IUserResponseBuilder, UserResponseBuilder>();
builder.Services.AddSingleton<IPlanResponseBuilder, PlanResponseBuilder>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3009")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

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

    if (!databaseContext.Subscription.Any())
    {
        databaseContext.Subscription.Add(new Subscription
        {
            PlanId = 1,
            SwitchedAt = DateTime.UtcNow
        });
    }

    databaseContext.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
