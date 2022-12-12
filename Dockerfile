FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build_env
WORKDIR /App

COPY api/*.csproj .
RUN dotnet restore

COPY api/. .
RUN dotnet publish -c Release -o out

#Create runtime docker image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App

COPY --from=build_env /App/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "c-sherp-project-api.dll"]
