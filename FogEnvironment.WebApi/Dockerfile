#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80 8009

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FogEnvironment.WebApi/FogEnvironment.WebApi.csproj", "FogEnvironment.WebApi/"]
COPY ["FogEnvironment.Domain/FogEnvironment.Domain.csproj", "FogEnvironment.Domain/"]
COPY ["NodeManager/FogEnvironment.NodeManager.csproj", "NodeManager/"]
COPY ["FogEnvironment.ImageServices/FaceDetectionApp/FogEnvironment.ImageProcessService.csproj", "FogEnvironment.ImageServices/FaceDetectionApp/"]
RUN dotnet restore "FogEnvironment.WebApi/FogEnvironment.WebApi.csproj"
COPY . .
WORKDIR "/src/FogEnvironment.WebApi"
RUN dotnet build "FogEnvironment.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FogEnvironment.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FogEnvironment.WebApi.dll"]