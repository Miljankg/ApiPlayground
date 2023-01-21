using ApiPerformanceTest.MinimalApi;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapWeatherForecastEndpoints();

app.Run();