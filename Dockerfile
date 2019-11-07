FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
RUN dotnet restore
RUN dotnet build
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
WORKDIR /app

RUN dotnet build

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "StringR.Backend.dll"]

EXPOSE 5000