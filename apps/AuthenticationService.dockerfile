FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# restore dependencies
COPY ./AuthenticationService/src/AuthenticationService.csproj ./AuthenticationService/src/AuthenticationService.csproj
COPY ./SharedKernel/SharedKernel.csproj ./SharedKernel/SharedKernel.csproj
RUN dotnet restore ./AuthenticationService/src

# Copy the source code
COPY ./AuthenticationService/src ./AuthenticationService/src
COPY ./SharedKernel ./SharedKernel

# Build and publish a release
RUN dotnet publish -c Release -o out ./AuthenticationService/src

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "./AuthenticationService.dll"]