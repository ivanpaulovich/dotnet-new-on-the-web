FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ../Tracking.OrderWebApi/Tracking.OrderWebApi.csproj ../Tracking.OrderWebApi/
COPY ../Tracking.Application/Tracking.Application.csproj ../Tracking.Application/
COPY ../Tracking.Domain/Tracking.Domain.csproj ../Tracking.Domain/
COPY ../Tracking.Infrastructure/Tracking.Infrastructure.csproj ../Tracking.Infrastructure/
RUN dotnet restore
COPY . .
WORKDIR /src/../Tracking.OrderWebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tracking.OrderWebApi.dll"]
