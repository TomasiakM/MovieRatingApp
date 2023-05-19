FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Reviews.Api.csproj", "./"]
RUN dotnet restore "./Reviews.Api.csproj"
COPY . .
RUN dotnet build "Reviews.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Reviews.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Reviews.Api.dll"]
