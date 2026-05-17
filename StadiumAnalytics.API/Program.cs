using Microsoft.EntityFrameworkCore;
using StadiumAnalytics.API.BackgroundServices;
using StadiumAnalytics.API.DbContexts;
using StadiumAnalytics.API.Repositories;
using StadiumAnalytics.API.Repositories.IRepositories;
using StadiumAnalytics.API.Services;
using StadiumAnalytics.API.Services.IServices;
using AutoMapper;

namespace StadiumAnalytics.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ISensorRepository, SensorRepository>();

            builder.Services.AddScoped<ISensorService, SensorService>();

            builder.Services.AddHostedService<SensorEventSimulatorService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
