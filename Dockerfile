# STAGE 1 - BUILD

# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY . ./
WORKDIR /source
RUN dotnet restore

# build app
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# STAGE 2 - DEPLOY

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Demo.Api.dll"]