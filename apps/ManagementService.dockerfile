FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# restore dependencies
COPY ./ManagementService/ManagementService.csproj ./ManagementService/ManagementService.csproj
COPY ./SharedKernel/SharedKernel.csproj ./SharedKernel/SharedKernel.csproj
RUN dotnet restore ./ManagementService

# Copy the source code
COPY ./ManagementService ./ManagementService
COPY ./SharedKernel ./SharedKernel

# Build and publish a release
RUN dotnet publish -c Release -o out ./ManagementService

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "./ManagementService.dll"]