FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["Air-BOT.csproj", "./"]
RUN dotnet restore "./Air-BOT.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Air-BOT.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Air-BOT.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Air-BOT.dll"]
