FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LearningCenterAPI/LearningCenterAPI.csproj", "LearningCenterAPI/"]
RUN dotnet restore "LearningCenterAPI/LearningCenterAPI.csproj"
COPY . .
WORKDIR "/src/LearningCenterAPI"
RUN dotnet build "LearningCenterAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningCenterAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningCenterAPI.dll"]
