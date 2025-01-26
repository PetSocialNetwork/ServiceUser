using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServiceUser.DataEntityFramework;
using ServiceUser.DataEntityFramework.Repositories;
using ServiceUser.Domain.Interfaces;
using ServiceUser.Domain.Services;
using ServiceUser.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CentralizedExceptionHandlingFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped(typeof(IRepositoryEF<>), typeof(EFRepository<>));
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
