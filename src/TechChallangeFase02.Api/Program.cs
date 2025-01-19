using TechChallangeFase02.Api.Extensions;
using TechChallangeFase02.Api.Middlewares;
using TechChallangeFase02.Infra.IoC.Extensions;
using TechChallangeFase02.Infra.IoC.Logging;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddCorsPolicy();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapperConfig();
builder.Services.AddDbContextConfig(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.UseHttpClientMetrics();

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration {
    LogLevel = LogLevel.Information,
}));

var app = builder.Build();


app.UseSwaggerDoc(app.Environment);
app.UseMetricServer();
app.UseHttpMetrics();
app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.UseHttpMetrics();
//app.UseAuthentication();
//app.UseAuthorization();
app.UseCorsPolicy();
app.MapControllers();
app.MapMetrics();
app.Run();

public partial class Program { }