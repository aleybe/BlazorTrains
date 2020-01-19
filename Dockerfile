FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY PerthTrains/PerthTrains.csproj ./
RUN dotnet restore "PerthTrains.csproj"
COPY PerthTrains/ .
RUN dotnet build "PerthTrains.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PerthTrains.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PerthTrains.dll"]