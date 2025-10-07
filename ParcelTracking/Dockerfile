# --- build stage ---
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj & restore as distinct layers
COPY ParcelTracking.csproj .
RUN dotnet restore

# copy rest of the source
COPY . .
# publish to /app/out
RUN dotnet publish -c Release -o /app/out

# --- runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://0.0.0.0:5173

COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "ParcelTracking.dll"]
