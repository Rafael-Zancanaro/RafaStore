#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RS.WebApp.MVC/RS.WebApp.MVC.csproj", "RS.WebApp.MVC/"]
RUN dotnet restore "RS.WebApp.MVC/RS.WebApp.MVC.csproj"
COPY . .
WORKDIR "/src/RS.WebApp.MVC"
RUN dotnet build "RS.WebApp.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.WebApp.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.WebApp.MVC.dll"]