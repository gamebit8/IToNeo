#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG NODE_IMAGE=node:16-bullseye
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM ${NODE_IMAGE} as node-build
WORKDIR /web/src
COPY Source/WebSPA/ClientApp .
RUN npm install -g npm@9.5.1
RUN npm install --legacy-peer-deps
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Source/WebSPA .
RUN dotnet restore "WebSPA.csproj"
RUN dotnet publish "WebSPA.csproj" -c Release -r linux-x64 --self-contained -o /app

FROM build AS publish

from base as final
WORKDIR /app
COPY --from=publish /app .
COPY --from=node-build /web/wwwroot ./wwwroot

ENTRYPOINT ["dotnet", "WebSPA.dll"]