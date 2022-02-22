FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaskCancellation.csproj", "./"]
RUN dotnet restore "TaskCancellation.csproj"
COPY . .
WORKDIR "/src/TaskCancellation"
RUN dotnet build "TaskCancellation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskCancellation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskCancellation.dll"]
