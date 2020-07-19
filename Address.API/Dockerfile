#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Address.API/Address.API.csproj", "Address.API/"]
RUN dotnet restore "Address.API/Address.API.csproj"
COPY . .
WORKDIR "/src/Address.API"
RUN dotnet build "Address.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Address.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Address.API.dll"]