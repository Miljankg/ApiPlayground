# ApiPlayground
Playground for trying different .NET Web API features.

# How to start current services and tests

## Starting Old Style vs Minimal API vs Fastendpoints API performance test
1. Run Old Style API: `dotnet run --configuration Release --profile http --project .\src\ApiPlayground.DefaultApi\ApiPlayground.DefaultApi.csproj`
3. Run Minimal API: `dotnet run --configuration Release --profile http --project .\src\ApiPlayground.MinimalApi\ApiPlayground.MinimalApi.csproj`
4. Run Fastendpoints API: `dotnet run --configuration Release --profile http --project .\src\ApiPlayground.FastEndpointsApi\ApiPlayground.FastEndpointsApi.csproj`
5. Run NBomber load test: `dotnet run --configuration Release --project .\test\ApiPlayground.LoadTest\ApiPlayground.LoadTest.csproj`

# Test Results

## Old Style vs Minimal API vs Fastendpoints API performance test

_Environment:_

| Component| Info             |
| -------- | ---------------- |
| CPU      | I7 8700K@4.3 GHz |
| RAM      | 32 GB            |

_Test Results:_

| scenario          | step               | load simulation   | latency stats (ms)                                         |
| ----------------- | ------------------ | ----------------- | ---------------------------------------------------------- |
| Old Style API     | old-style-api      | keep_constant: 24 | ok: 5969484, fail: 0, RPS: 20557.7, p50 = 0.91, p99 = 4.48 |
| Minimal API       | minimum-api        | keep_constant: 24 | ok: 7379874, fail: 0, RPS: 25527.7, p50 = 0.78, p99 = 4    |
| FastEndpoints API | fast-endpoints-api | keep_constant: 24 | ok: 6851492, fail: 0, RPS: 23168.4, p50 = 0.84, p99 = 4.21 |

| Scenario          | Difference in requests processed |
| ----------------  | -------------------------------- |
| Old Style API     | 100%                             |
| Minimal API       | 120%                             |
| FastEndpoints API | 113%                             |
