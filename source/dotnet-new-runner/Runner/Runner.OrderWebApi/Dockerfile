FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ../Runner.OrderWebApi/Runner.OrderWebApi.csproj ../Runner.OrderWebApi/
COPY ../Runner.Application/Runner.Application.csproj ../Runner.Application/
COPY ../Runner.Domain/Runner.Domain.csproj ../Runner.Domain/
COPY ../Runner.Infrastructure/Runner.Infrastructure.csproj ../Runner.Infrastructure/
RUN dotnet restore
COPY . .
WORKDIR /src/../Runner.OrderWebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Runner.OrderWebApi.dll"]
