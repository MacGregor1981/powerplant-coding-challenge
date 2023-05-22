#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductionPlan/ProductionPlan.csproj", "ProductionPlan/"]
RUN dotnet restore "ProductionPlan/ProductionPlan.csproj"
COPY . .
WORKDIR "/src/ProductionPlan"
RUN dotnet build "ProductionPlan.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductionPlan.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductionPlan.dll"]

### https://hub.docker.com/_/microsoft-dotnet
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /source
#
## copy csproj and restore as distinct layers
#COPY *.sln .
#COPY ProductionPlan/*.csproj ./ProductionPlan/
#RUN dotnet restore
#
## copy everything else and build app
#COPY ProductionPlan/. ./ProductionPlan/
#WORKDIR /source/ProductionPlan
#RUN dotnet publish -c release -o /app --no-restore
#
## final stage/image
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#COPY --from=build /app ./
#ENTRYPOINT ["dotnet", "ProductionPlan.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 8888
#
#FROM FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["ProductionPlan/ProductionPlan.csproj", "ProductionPlan/"]
#RUN dotnet restore "ProductionPlan/ProductionPlan.csproj"
#COPY . .
#WORKDIR "/src/ProductionPlan"
#RUN dotnet build "ProductionPlan.csproj" -c Release -o /app/build
#FROM build AS publish
#RUN dotnet publish "ProductionPlan.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProductionPlan.dll"]