using RestCountries.Domain;
using RestCountries.Infrastructure.Countries;
using RestCountries.ApplicationServices.Countries;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using RestCountries.ApplicationServices.Regions;
using RestCountries.ApplicationServices.Subregions;

var builder = WebApplication.CreateBuilder(args);

//Get appsettings values
var appOptions = builder.Configuration.Get<AppOptions>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<RegionService>();
builder.Services.AddScoped<SubregionService>();

// Add repositories
builder.Services.AddScoped<ICountryRepo, CountryRepo>(_ => new CountryRepo() { BaseUrl = appOptions.BaseUrl });

//Add Logging
Enum.TryParse(appOptions.Logging.Level, out LogEventLevel logEventLevel);
var loggerConfig = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .MinimumLevel.ControlledBy(new LoggingLevelSwitch(logEventLevel))
        .WriteTo.File(appOptions.Logging.OutputPath, outputTemplate: appOptions.Logging.OutputTemplate, rollingInterval: RollingInterval.Day);
Log.Logger = loggerConfig.CreateLogger();

builder.Services.AddSingleton(Log.Logger);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Countries}/{action=Index}/{name?}");

app.Run();
