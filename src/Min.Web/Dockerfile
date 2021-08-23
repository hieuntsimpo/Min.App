#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Min.App.Web.csproj", "Min.Web/"]
RUN dotnet restore "Min.App.Web.csproj"
COPY . .
WORKDIR "/src/Min.Web"
RUN dotnet build "Min.App.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Min.App.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Min.Web.dll"]