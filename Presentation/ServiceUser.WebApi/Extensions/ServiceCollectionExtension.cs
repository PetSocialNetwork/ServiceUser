using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServiceUser.WebApi.Filters;
using ServiceUser.DataEntityFramework.Repositories;
using ServiceUser.DataEntityFramework;
using ServiceUser.Domain.Interfaces;
using ServiceUser.Domain.Services;

namespace ServiceUser.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            services.AddApplicationComponents(configuration);
        }

        public static void ConfigureMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddControllers(options =>
            {
                options.Filters.Add<CentralizedExceptionHandlingFilter>();
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void AddApplicationComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddDomainServices();
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            services.AddScoped(typeof(IRepositoryEF<>), typeof(EFRepository<>));
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }

        private static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<UserProfileService>();
        }
    }
}
