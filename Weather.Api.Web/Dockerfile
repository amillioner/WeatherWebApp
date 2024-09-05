#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Weather.Api.Web/Weather.Api.Web.csproj", "Weather.Api.Web/"]
COPY ["Weather.Ap.Geo/Weather.Ap.Geo.csproj", "Weather.Ap.Geo/"]
COPY ["Weather.Api.Common/Weather.Api.Common.csproj", "Weather.Api.Common/"]
COPY ["Weather.Api.Data/Weather.Api.Data.csproj", "Weather.Api.Data/"]
COPY ["Weather.Api.Graphql/Weather.Api.Graphql.csproj", "Weather.Api.Graphql/"]
COPY ["Weather.Api.Service/Weather.Api.Service.csproj", "Weather.Api.Service/"]
RUN dotnet restore "./Weather.Api.Web/Weather.Api.Web.csproj"
COPY . .
WORKDIR "/src/Weather.Api.Web"
RUN dotnet build "./Weather.Api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Weather.Api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.Api.Web.dll"]