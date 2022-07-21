#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RS.Pagamento.API/RS.Pagamento.API.csproj", "RS.Pagamento.API/"]
RUN dotnet restore "RS.Pagamento.API/RS.Pagamento.API.csproj"
COPY . .
WORKDIR "/src/RS.Pagamento.API"
RUN dotnet build "RS.Pagamento.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.Pagamento.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Pagamento.API.dll"]