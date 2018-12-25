FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Dotnet/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./Dotnet/ ./
RUN dotnet publish -c Release -o out Sklep.csproj

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Sklep.dll"]