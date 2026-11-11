FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/CS.Identity.API/CS.Identity.API.csproj", "src/CS.Identity.API/"]
COPY ["src/CS.Identity.Application/CS.Identity.Application.csproj", "src/CS.Identity.Application/"]
COPY ["src/CS.Identity.Domain/CS.Identity.Domain.csproj", "src/CS.Identity.Domain/"]
COPY ["src/CS.Identity.Infrastructure/CS.Identity.Infrastructure.csproj", "src/CS.Identity.Infrastructure/"]
RUN dotnet restore "src/CS.Identity.API/CS.Identity.API.csproj"
COPY . .
RUN dotnet publish "src/CS.Identity.API/CS.Identity.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CS.Identity.API.dll"]
