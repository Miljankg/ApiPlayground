using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

namespace ApiPerformanceTest.LoadTest;

public static class Steps
{
    public static IStep CreateGetWeatherForecastStep(string name, string url)
    {
        var clientFactory = HttpClientFactory.Create(name: $"{name}Factory");
        
        return Step.Create(name, clientFactory, async context =>
        {
            var response = await context.Client.GetAsync(url);

            return response.IsSuccessStatusCode
                ? Response.Ok(statusCode: (int)response.StatusCode)
                : Response.Fail(statusCode: (int)response.StatusCode);
        });
    }
}