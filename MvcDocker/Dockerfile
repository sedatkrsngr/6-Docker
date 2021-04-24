FROM mcr.microsoft.com/dotnet/sdk:3.1 as sdk
WORKDIR /app
COPY  *.csproj .
RUN dotnet restore
COPY  . .
RUN dotnet publish MvcDocker.csproj -c Release - o out 
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=sdk /app/out .
ENV ASPNETCORE_URLS "http://*:4500"
ENTRYPOINT ["dotnet", "MvcDocker.dll"]
