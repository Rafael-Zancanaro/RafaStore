#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RS.Carrinho.API/RS.Carrinho.API.csproj", "RS.Carrinho.API/"]
RUN dotnet restore "RS.Carrinho.API/RS.Carrinho.API.csproj"
COPY . .
WORKDIR "/src/RS.Carrinho.API"
RUN dotnet build "RS.Carrinho.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.Carrinho.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Carrinho.API.dll"]