FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/__BoundedContext__.__ServiceName__.Api/__BoundedContext__.__ServiceName__.Api.csproj", "src/__BoundedContext__.__ServiceName__.Api/"]
RUN dotnet restore "src/__BoundedContext__.__ServiceName__.Api/__BoundedContext__.__ServiceName__.Api.csproj"
COPY . .
WORKDIR "/src/src/__BoundedContext__.__ServiceName__.Api"
RUN dotnet build "__BoundedContext__.__ServiceName__.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "__BoundedContext__.__ServiceName__.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "__BoundedContext__.__ServiceName__.Api.dll"]
