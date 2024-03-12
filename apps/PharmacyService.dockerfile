FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# restore dependencies
COPY ./PharmacyService/src/Api/Api.csproj ./PharmacyService/src/Api/Api.csproj
COPY ./SharedKernel/SharedKernel.csproj ./SharedKernel/SharedKernel.csproj
RUN dotnet restore ./PharmacyService/src/Api

# Copy the source code
COPY ./PharmacyService/src ./PharmacyService/src
COPY ./SharedKernel ./SharedKernel

# Build and publish a release
RUN dotnet publish -c Release -o out ./PharmacyService/src/Api

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "./Api.dll"]