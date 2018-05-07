FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ../Cart.OrderWebApi/Cart.OrderWebApi.csproj ../Cart.OrderWebApi/
COPY ../Cart.Application/Cart.Application.csproj ../Cart.Application/
COPY ../Cart.Domain/Cart.Domain.csproj ../Cart.Domain/
COPY ../Cart.Infrastructure/Cart.Infrastructure.csproj ../Cart.Infrastructure/
RUN dotnet restore
COPY . .
WORKDIR /src/../Cart.OrderWebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cart.OrderWebApi.dll"]
