using ApiPerformanceTest.LoadTest;
using NBomber.CSharp;

const string oldStyleApiUrl = "http://localhost:5108/WeatherForecast";
const string minimumApiUrl = "http://localhost:5066/WeatherForecast";
const string fastEndpointsApiUrl = "http://localhost:5071/WeatherForecast";

var oldStyleApiStep = Steps.CreateGetWeatherForecastStep(name: "old-style-api", oldStyleApiUrl);
var minimumApiStep = Steps.CreateGetWeatherForecastStep(name: "minimum-api", minimumApiUrl);
var fastEndpointsApiStep = Steps.CreateGetWeatherForecastStep(name: "fast-endpoints-api", fastEndpointsApiUrl);

var oldStyleApiScenario = Scenarios.CreateSimpleApiLoadTest(name: "Old Style API", oldStyleApiStep);
var minimalApiScenario = Scenarios.CreateSimpleApiLoadTest(name: "Minimal API", minimumApiStep);
var fastEndpointsApiScenario = Scenarios.CreateSimpleApiLoadTest(name: "FastEndpoints API", fastEndpointsApiStep);

NBomberRunner
    .RegisterScenarios(oldStyleApiScenario, minimalApiScenario, fastEndpointsApiScenario)
    .Run();