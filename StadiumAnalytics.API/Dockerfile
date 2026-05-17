# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["StadiumAnalytics.API/StadiumAnalytics.API.csproj", "StadiumAnalytics.API/"]

RUN dotnet restore "./StadiumAnalytics.API/StadiumAnalytics.API.csproj"

COPY . .

WORKDIR "/src/StadiumAnalytics.API"

RUN dotnet build "StadiumAnalytics.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "StadiumAnalytics.API.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# Final runtime stage
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "StadiumAnalytics.API.dll"]