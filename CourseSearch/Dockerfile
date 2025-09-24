FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 6003

ENV ASPNETCORE_URLS=http://+:6003

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["CourseSearch.csproj", "./"]
RUN dotnet restore "CourseSearch.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CourseSearch.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CourseSearch.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseSearch.dll"]
