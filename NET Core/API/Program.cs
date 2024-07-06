using DataAccess;
using Services;
using Microsoft.EntityFrameworkCore;
using Services.Operations.Interfaces;
using Services.Operations;
using Core;
using Services.Containers.Interfaces;
using Services.Containers;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("default");

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IUnitOfWork, AppDbContext>();
            builder.Services.AddScoped<IUnitOfWork, AppDbContext>();
            builder.Services.AddScoped<IOperationService, OperationService>();
            builder.Services.AddScoped<IContainerService, ContainerService>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
