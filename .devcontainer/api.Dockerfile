FROM mcr.microsoft.com/devcontainers/dotnet:0-6.0

RUN apt-get update && apt-get install -y \
  default-mysql-client \
  && rm -rf /var/lib/apt/lists/*
