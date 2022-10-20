FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ocelot.Demo.csproj", "."]
RUN dotnet restore "./Ocelot.Demo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Ocelot.Demo.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Ocelot.Demo.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocelot.Demo.dll"]