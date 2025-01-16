# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TechChallangeFase02.Api/TechChallangeFase02.Api.csproj", "./TechChallangeFase02.Api/"]
COPY ["TechChallangeFase02.Infra.IoC/TechChallangeFase02.Infra.IoC.csproj", "./TechChallangeFase02.Infra.IoC/"]
COPY ["TechChallangeFase02.Application/TechChallangeFase02.Application.csproj", "./TechChallangeFase02.Application/"]
COPY ["TechChallangeFase02.Domain/TechChallangeFase02.Domain.csproj", "./TechChallangeFase02.Domain/"]
COPY ["TechChallangeFase02.Domain.Core/TechChallangeFase02.Domain.Core.csproj", "./TechChallangeFase02.Domain.Core/"]
COPY ["TechChallangeFase02.Infra.Data/TechChallangeFase02.Infra.Data.csproj", "./TechChallangeFase02.Infra.Data/"]
COPY . .
WORKDIR "/src/TechChallangeFase02.Api"
RUN dotnet build "./TechChallangeFase02.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TechChallangeFase02.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallangeFase02.Api.dll"]