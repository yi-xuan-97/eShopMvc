﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim-amd64 AS basebase
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV eShopDb="Server=10.0.0.29,1433; Database=eShopDb; User=SA; Password=NewStrongPassword456; TrustServerCertificate=True;"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eShop/eShop.csproj", "eShop/"]
RUN dotnet restore "eShop/eShop.csproj"
COPY . .
WORKDIR "/src/eShop"
RUN dotnet build "eShop.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "eShop.csproj" -c $BUILD_CONFIGURATION -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShop.dll"]
