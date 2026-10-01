FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER $APP_UID
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Copy project files first
COPY ["Evora.API/Evora.API.csproj", "Evora.API/"]
COPY ["Evora.Domain/Evora.Domain.csproj", "Evora.Domain/"]
COPY ["Evora.Interface/Evora.Interface.csproj", "Evora.Interface/"]
COPY ["Evora.Repository/Evora.Repository.csproj", "Evora.Repository/"]
COPY ["Evora.Service/Evora.Service.csproj", "Evora.Service/"]

# Restore dependencies
RUN dotnet restore "./Evora.API/Evora.API.csproj"

# Copy the remaining source code
COPY . .

# Build API
WORKDIR "/src/Evora.API"

RUN dotnet build "./Evora.API.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Evora.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Evora.API.dll"]
