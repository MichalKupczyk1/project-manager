using ProjectManager.Database;
using ProjectManager.Database.Repositories;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Middleware.Exception;
using System.Reflection;

namespace ProjectManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

            var applicationAssembly = Assembly.Load("ProjectManager.Application");
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.ConfigureExceptionHandler();

            app.MapControllers();

            app.Run();
        }
    }
}
