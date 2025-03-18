# Build bosqichi uchun base image
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build
WORKDIR /src

# Proyekt fayllarini nusxalash
COPY ["Management.Core/Management.Domain.csproj", "Management.Core/"]
RUN dotnet restore "Management.Core/Management.Domain.csproj"

COPY . .
WORKDIR "/src/Management.Core"
RUN dotnet build "Management.Domain.csproj" -c Release -o /app/build

# Publish bosqichi
FROM build AS publish
RUN dotnet publish "Management.Domain.csproj" -c Release -o /app/publish

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Management.Domain.dll"] 