FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SalesTaxes.App/SalesTaxes.App.csproj", "SalesTaxes.App/"]
RUN dotnet restore "SalesTaxes.App/SalesTaxes.App.csproj"
COPY . .
WORKDIR "/src/SalesTaxes.App"
RUN dotnet build "SalesTaxes.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalesTaxes.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalesTaxes.App.dll"]
