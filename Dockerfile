FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-focal AS build
WORKDIR /src
COPY . .
RUN dotnet restore  "./CommandRestClient/CommandRestClient.csproj"
WORKDIR "/src/CommandRestClient"
RUN dotnet build "CommandRestClient.csproj" -c Release -o /app

FROM build AS publish
WORKDIR "/src/CommandRestClient"
RUN dotnet publish "CommandRestClient.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "CommandRestClient.dll", "--server.urls", "http://0.0.0.0:5000"]