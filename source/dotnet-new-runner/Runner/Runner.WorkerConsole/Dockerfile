FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY ../Runner.WorkerConsole/Runner.WorkerConsole.csproj ../Runner.WorkerConsole/
COPY ../Runner.Application/Runner.Application.csproj ../Runner.Application/
COPY ../Runner.Domain/Runner.Domain.csproj ../Runner.Domain/
COPY ../Runner.Infrastructure/Runner.Infrastructure.csproj ../Runner.Infrastructure/
RUN dotnet restore
COPY . .
WORKDIR /src/../Runner.WorkerConsole
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Runner.WorkerConsole.dll"]