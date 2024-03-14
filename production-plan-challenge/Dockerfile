# Use the official Microsoft .NET 7 ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8888

# Set environment variable to listen on port 8888
ENV ASPNETCORE_URLS=http://+:8888

# Use the .NET 7 SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["production-plan-challenge.csproj", "./"]
RUN dotnet restore "production-plan-challenge.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "production-plan-challenge.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "production-plan-challenge.csproj" -c Release -o /app/publish

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the ASPNETCORE_ENVIRONMENT environment variable
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "production-plan-challenge.dll"]
