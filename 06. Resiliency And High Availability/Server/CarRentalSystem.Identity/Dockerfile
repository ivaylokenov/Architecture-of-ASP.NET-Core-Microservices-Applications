FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CarRentalSystem.Identity/CarRentalSystem.Identity.csproj", "CarRentalSystem.Identity/"]
COPY ["CarRentalSystem/CarRentalSystem.csproj", "CarRentalSystem/"]
RUN dotnet restore "CarRentalSystem.Identity/CarRentalSystem.Identity.csproj"
COPY . .
WORKDIR "/src/CarRentalSystem.Identity"
RUN dotnet build "CarRentalSystem.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalSystem.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRentalSystem.Identity.dll"]