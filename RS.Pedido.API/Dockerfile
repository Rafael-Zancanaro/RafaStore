#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RS.Pedido.API/RS.Pedido.API.csproj", "RS.Pedido.API/"]
RUN dotnet restore "RS.Pedido.API/RS.Pedido.API.csproj"
COPY . .
WORKDIR "/src/RS.Pedido.API"
RUN dotnet build "RS.Pedido.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.Pedido.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Pedido.API.dll"]