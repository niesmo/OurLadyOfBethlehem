FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY OLB.WebAPI/OLB.WebAPI.csproj OLB.WebAPI/
RUN dotnet restore OLB.WebAPI/OLB.WebAPI.csproj
COPY . .
WORKDIR /src/OLB.WebAPI
RUN dotnet build OLB.WebAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OLB.WebAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OLB.WebAPI.dll"]
