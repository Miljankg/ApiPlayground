FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiPerformanceTest/ApiPerformanceTest.csproj", "ApiPerformanceTest/"]
RUN dotnet restore "ApiPerformanceTest/ApiPerformanceTest.csproj"
COPY . .
WORKDIR "/src/ApiPerformanceTest"
RUN dotnet build "ApiPerformanceTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiPerformanceTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiPerformanceTest.dll"]
