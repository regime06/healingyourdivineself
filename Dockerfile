FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .

RUN dotnet publish HealingDivineSelf.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false

EXPOSE 10000

ENTRYPOINT ["dotnet", "HealingDivineSelf.dll"]