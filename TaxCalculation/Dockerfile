FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 6002

ENV ASPNETCORE_URLS=http://+:6002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TaxCalculation.csproj", "./"]
RUN dotnet restore "TaxCalculation.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TaxCalculation.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TaxCalculation.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxCalculation.dll"]
