using NBomber.Contracts;
using NBomber.CSharp;

namespace ApiPerformanceTest.LoadTest;

internal static class Scenarios
{
    public static Scenario CreateSimpleApiLoadTest(string name, IStep step)
    {
        return ScenarioBuilder
            .CreateScenario(name, step)
            .WithWarmUpDuration(TimeSpan.FromSeconds(24))
            .WithLoadSimulations(Simulation.KeepConstant(copies: 24, during: TimeSpan.FromSeconds(60)));
    }
}