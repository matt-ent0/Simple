FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["SimpleGateway.csproj", "./"]
RUN dotnet restore "SimpleGateway.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SimpleGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleGateway.dll"]
