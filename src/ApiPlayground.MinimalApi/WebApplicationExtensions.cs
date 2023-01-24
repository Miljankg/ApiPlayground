namespace ApiPerformanceTest.MinimalApi;

internal static class WebApplicationExtensions
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public static IEndpointConventionBuilder MapWeatherForecastEndpoints(this WebApplication app)
    {
        return app.MapGet("/WeatherForecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

            return Task.FromResult(forecast);
        });
    }
}