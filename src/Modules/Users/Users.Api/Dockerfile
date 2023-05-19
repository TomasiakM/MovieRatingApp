FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Users.Api.csproj", "./"]
RUN dotnet restore "./Users.Api.csproj"
COPY . .
RUN dotnet build "Users.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Users.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Users.Api.dll"]
