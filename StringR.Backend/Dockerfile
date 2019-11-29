# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "StringR.Backend.dll"]

EXPOSE 5000