using JobsityApi.Data;
using JobsityApi.Services;
using JobsityApi.Utils;
using JobsityApi.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.RegisterDbContext(connectionString);
builder.Services.AddControllers();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureAuthentication(builder.Configuration["AuthSettings:Key"]);
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<GlobalExceptionMiddleware>();
builder.Services.RegisterGzipCompression();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());
app.UseMiddleware<GlobalExceptionMiddleware>();

app.Run();