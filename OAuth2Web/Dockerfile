#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OAuth2Web/OAuth2Web.csproj", "OAuth2Web/"]
RUN dotnet restore "OAuth2Web/OAuth2Web.csproj"
COPY . .
WORKDIR "/src/OAuth2Web"
RUN dotnet build "OAuth2Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OAuth2Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OAuth2Web.dll"]