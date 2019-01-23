FROM microsoft/dotnet:sdk AS build-env

MAINTAINER Jakub Gruda & Krzyszfot Marczyński

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Dotnet/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./Dotnet/ ./
COPY ./shared/ ./wwwroot/shared

RUN dotnet publish -c Release -o out Shop.csproj

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Shop.dll"]