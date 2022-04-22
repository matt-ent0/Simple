FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7001

ENV ASPNETCORE_URLS=http://+:7001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleAPI.csproj", "./"]
RUN dotnet restore "SimpleAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SimpleAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleAPI.dll"]
