FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /
COPY ["Graphql.API/Graphql.API.csproj", "Graphql.API/"]
COPY ["Graphql.Infra/Graphql.Infra.csproj", "Graphql.Infra/"]
COPY ["Graphql.Core/Graphql.Core.csproj", "Graphql.Core/"]
RUN dotnet restore "Graphql.API/Graphql.API.csproj"
COPY . .
WORKDIR "/Graphql.API"
RUN dotnet build "Graphql.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Graphql.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Graphql.API.dll"]