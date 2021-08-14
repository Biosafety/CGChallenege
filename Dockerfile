
# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ApiCodeChallenge/*.csproj ./ApiCodeChallenge/
COPY ApiCodeChallenge.Common/*.csproj ./ApiCodeChallenge.Common/
COPY ApiCodeChallenge.Controller.Tests/*.csproj ./ApiCodeChallenge.Controller.Tests/
COPY ApiCodeChallenge.Repositories/*.csproj ./ApiCodeChallenge.Repositories/
COPY ApiCodeChallenge.Services/*.csproj ./ApiCodeChallenge.Services/

RUN dotnet restore

# copy everything else and build app
COPY ApiCodeChallenge/. ./ApiCodeChallenge/
COPY ApiCodeChallenge.Common/. ./ApiCodeChallenge.Common/
COPY ApiCodeChallenge.Controller.Tests/. ./ApiCodeChallenge.Controller.Tests/
COPY ApiCodeChallenge.Repositories/. ./ApiCodeChallenge.Repositories/
COPY ApiCodeChallenge.Services/. ./ApiCodeChallenge.Services/

WORKDIR /source/ApiCodeChallenge
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ApiCodeChallenge.dll"]