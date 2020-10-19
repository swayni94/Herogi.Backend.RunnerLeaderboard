#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Herogi.Leaderboard.Api/Herogi.Leaderboard.Api.csproj Herogi.Leaderboard.Api/
COPY Herogi.Leaderboard.Service/Herogi.Leaderboard.Service.csproj Herogi.Leaderboard.Service/
COPY Herogi.Leaderboard.Data/Herogi.Leaderboard.Data.csproj Herogi.Leaderboard.Data/
RUN dotnet restore "Herogi.Leaderboard.Api/Herogi.Leaderboard.Api.csproj"
COPY . .
WORKDIR "/src/Herogi.Leaderboard.Api"
RUN dotnet build "Herogi.Leaderboard.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Herogi.Leaderboard.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Herogi.Leaderboard.Api.dll"]
