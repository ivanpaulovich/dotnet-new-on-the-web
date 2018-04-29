FROM microsoft/dotnet:2.1-sdk
COPY . .
RUN dotnet new --install Paulovich.Caju
WORKDIR /Runner/Runner.WorkerConsole
RUN dotnet publish -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "Runner.WorkerConsole.dll"]