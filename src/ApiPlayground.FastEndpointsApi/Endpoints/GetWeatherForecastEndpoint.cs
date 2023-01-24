using FastEndpoints;

namespace ApiPerformanceTest.FastEndpointsApi.Endpoints;

internal class GetWeatherForecastEndpoint : EndpointWithoutRequest
{
    private static readonly string[] Summaries = 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("WeatherForecast");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        await SendAsync(forecast, cancellation: ct);
    }
}