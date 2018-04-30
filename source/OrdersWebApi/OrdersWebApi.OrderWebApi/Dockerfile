FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ../OrdersWebApi.OrderWebApi/OrdersWebApi.OrderWebApi.csproj ../OrdersWebApi.OrderWebApi/
COPY ../OrdersWebApi.Application/OrdersWebApi.Application.csproj ../OrdersWebApi.Application/
COPY ../OrdersWebApi.Domain/OrdersWebApi.Domain.csproj ../OrdersWebApi.Domain/
COPY ../OrdersWebApi.Infrastructure/OrdersWebApi.Infrastructure.csproj ../OrdersWebApi.Infrastructure/
RUN dotnet restore
COPY . .
WORKDIR /src/../OrdersWebApi.OrderWebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OrdersWebApi.OrderWebApi.dll"]
