FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build_env

WORKDIR /App

RUN dotnet tool install --global dotnet-ef --version 6.0.11
ENV PATH="$PATH:/root/.dotnet/tools"
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build_env
#
#WORKDIR /App
#
#COPY ./api/*.csproj .
#RUN dotnet restore
#COPY ./api/. .
##RUN dotnet tool install --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"
