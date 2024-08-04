using Asp.Versioning;
using IDP.Application.Handler.Command.User;
using IDP.Domain.IRepository.Command;
using IDP.Infra.Repository.Command;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region RedsiConfig
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetValue<string>("CashSetting:RedisUrl");

});
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(typeof(UserHandler).GetTypeInfo().Assembly);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOtpRedisRepository, OtpRedisRepository>();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});
Auth.Extensions.AddJWT(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
