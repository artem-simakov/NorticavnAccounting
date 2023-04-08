using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NorticavnAccounting.BLL.Interfaces;
using NorticavnAccounting.BLL.Profiles;
using NorticavnAccounting.BLL.Services;
using NorticavnAccounting.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

RunMigrations(app.Services);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddTransient<IEmployeeService, EmployeeService>();
    services.AddTransient<IPositionService, PositionService>();
    services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    var connectionString = configuration.GetConnectionString("NorticavnAccountingDatabase");

    services.AddDbContext<NorticavnAccountingDbContext>(x =>
        x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    services.AddAutoMapper(typeof(EmployeeProfile).Assembly);
}

void RunMigrations(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<NorticavnAccountingDbContext>();
    service.Database.Migrate();
}