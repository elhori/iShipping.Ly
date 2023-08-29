using FluentValidation;
using iShipping.Ly.Application;
using iShipping.Ly.Infra;
using iShipping.Ly.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddInfra(builder.Configuration);

            builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.RegisterSwaggerServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //TODO: Remove Swagger UI from Production
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<DataContext>();

                context.Database.Migrate();
            }

            //DataSeeder.SeedAsync(app.Services).GetAwaiter().GetResult();

            app.Run();
        }
    }
}