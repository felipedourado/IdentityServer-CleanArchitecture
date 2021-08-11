#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Apps/SquadPremium.Api/SquadPremium.Api.csproj", "src/Apps/SquadPremium.Api/"]
COPY ["src/Common/SquadPremium.Infrastructure/SquadPremium.Infrastructure.csproj", "src/Common/SquadPremium.Api.Infrastructure/"]
COPY ["src/Common/SquadPremium.Application/SquadPremium.Application.csproj", "src/Common/SquadPremium.Api.Application/"]
COPY ["src/Common/SquadPremium.Domain/SquadPremium.Domain.csproj", "src/Common/SquadPremium.Api.Domain/"]
RUN dotnet restore "src/Apps/SquadPremium.Api/SquadPremium.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/SquadPremium.Api"
RUN dotnet build "SquadPremium.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SquadPremium.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SquadPremium.Api.dll"]