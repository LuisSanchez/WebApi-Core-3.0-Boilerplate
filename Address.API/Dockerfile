#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# https://docs.microsoft.com/en-us/dotnet/core/install/linux-alpine
# The Alpine SDK image does have cultures installed. The runtime images don't have cultures installed.
# https://github.com/dotnet/corefx/blob/8245ee1e8f6063ccc7a3a60cafe821d29e85b02f/Documentation/architecture/globalization-invariant-mode.md
# https://hub.docker.com/_/microsoft-dotnet-core-aspnet/ docker list of images from OS
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.6-alpine3.12 AS base
WORKDIR /app
EXPOSE 80

# Install cultures (same approach as Alpine SDK image)
RUN apk add icu-libs

# Disable the invariant mode (set in base image)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

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