FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5005

ENV ASPNETCORE_URLS=http://+:5005

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ServiceA.csproj", ""]
RUN dotnet restore "./ServiceA.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ServiceA.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ServiceA.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceA.dll"]
