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
#endregion

#region DI
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
