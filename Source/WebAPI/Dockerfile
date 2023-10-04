#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/WebAPI/WebAPI.csproj", "Source/WebAPI/"]
COPY ["Source/ApplicationCore/ApplicationCore.csproj", "Source/ApplicationCore/"]
COPY ["Source/Infrastructure/Infrastructure.csproj", "Source/Infrastructure/"]
RUN dotnet restore "Source/WebAPI/WebAPI.csproj"
COPY . .
Copy Source/itoneo.pfx .
WORKDIR "/src/Source/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -r linux-x64 --self-contained -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=build /src/itoneo.pfx .
COPY --from=publish /app/publish .
COPY --from=build /src/Source/Infrastructure/Csv .
ENTRYPOINT ["dotnet", "WebAPI.dll"]