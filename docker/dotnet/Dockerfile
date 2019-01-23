FROM microsoft/dotnet:sdk AS build-env

MAINTAINER Jakub Gruda & Krzyszfot Marczyński

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Dotnet/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./Dotnet/ ./
COPY ./shared/scripts ./wwwroot/js
COPY ./shared/styles ./wwwroot/css
COPY ./shared/images ./wwwroot/images

RUN dotnet publish -c Release -o out Shop.csproj

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Shop.dll"]