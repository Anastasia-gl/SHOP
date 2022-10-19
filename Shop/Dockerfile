
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Shop.sln ./
COPY Shop.Backend/Core/Shop.Domain/*.csproj ./Shop.Backend/Core/Shop.Domain/
COPY Shop.Backend/Infrastructure/Shop.Context/*.csproj ./Shop.Backend/Infrastructure/Shop.Context/
COPY Shop.Backend/Infrastructure/Shop.Persistence/*.csproj ./Shop.Backend/Infrastructure/Shop.Persistence/
COPY Shop.Backend/WebApi/Shop.WebApi/*.csproj ./Shop.Backend/WebApi/Shop.WebApi/
COPY Shop.Identity/*.csproj ./Shop.Identity/

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish Shop.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:80
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 7213
ENTRYPOINT ["dotnet", "Shop.WebApi.dll"]