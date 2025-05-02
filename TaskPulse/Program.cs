using Microsoft.EntityFrameworkCore;
using TaskPulse.Repository;
using TaskPulse.Repository.Interfaces;
using TaskPulse.Repository.Repositories;
using TaskPulse.Service.Interfaces;
using TaskPulse.Service.Services;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"), sqlOptions => sqlOptions.MigrationsAssembly("TaskPulse.Repository"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
        else
        {
            policy.WithOrigins("https://red-water-01e6c4300.6.azurestaticapps.net")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    });
});
#endregion

#region DI
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
