
using StarWarsApi.Constants;
using StarWarsApi.Controllers;
using StarWarsApi.Services;

namespace StarWarsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:3000");
                });
            });

            // Register Services
            RegisterProjectServices(builder);

            // Register Options
            RegisterProjectOptions(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowFrontend");

            app.MapControllers();

            app.Run();
        }


        /// <summary>
        /// Register all of the services in the project here
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterProjectServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IPeopleService, PeopleService>();
        }

        /// <summary>
        /// Register all of the options in the project here
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterProjectOptions(WebApplicationBuilder builder)
        {
            builder.Services.Configure<Api>(builder.Configuration.GetSection(nameof(Api)));
        }
    }
}
