#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Basket/Market.Basket.Api/Market.Basket.Api.csproj", "Services/Basket/Market.Basket.Api/"]
COPY ["Services/Basket/Market.Basket.Application/Market.Basket.Application.csproj", "Services/Basket/Market.Basket.Application/"]
COPY ["Services/Basket/Market.Basket.Data/Market.Basket.Data.csproj", "Services/Basket/Market.Basket.Data/"]
COPY ["Common/Market.Common/Market.Common.csproj", "Common/Market.Common/"]
RUN dotnet restore "Services/Basket/Market.Basket.Api/Market.Basket.Api.csproj"
COPY . .
WORKDIR "/src/Services/Basket/Market.Basket.Api"
RUN dotnet build "Market.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Market.Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Market.Basket.Api.dll"]
