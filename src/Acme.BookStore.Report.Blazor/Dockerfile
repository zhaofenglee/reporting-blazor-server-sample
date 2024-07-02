FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Acme.BookStore.Report.Blazor/Acme.BookStore.Report.Blazor.csproj", "src/Acme.BookStore.Report.Blazor/"]
COPY ["src/Acme.BookStore.Report.Application/Acme.BookStore.Report.Application.csproj", "src/Acme.BookStore.Report.Application/"]
COPY ["src/Acme.BookStore.Report.Domain/Acme.BookStore.Report.Domain.csproj", "src/Acme.BookStore.Report.Domain/"]
COPY ["src/Acme.BookStore.Report.Domain.Shared/Acme.BookStore.Report.Domain.Shared.csproj", "src/Acme.BookStore.Report.Domain.Shared/"]
COPY ["src/Acme.BookStore.Report.Application.Contracts/Acme.BookStore.Report.Application.Contracts.csproj", "src/Acme.BookStore.Report.Application.Contracts/"]
COPY ["src/Acme.BookStore.Report.HttpApi/Acme.BookStore.Report.HttpApi.csproj", "src/Acme.BookStore.Report.HttpApi/"]
COPY ["src/Acme.BookStore.Report.EntityFrameworkCore/Acme.BookStore.Report.EntityFrameworkCore.csproj", "src/Acme.BookStore.Report.EntityFrameworkCore/"]
RUN dotnet restore "src/Acme.BookStore.Report.Blazor/Acme.BookStore.Report.Blazor.csproj"
COPY . .
WORKDIR "/src/src/Acme.BookStore.Report.Blazor"
RUN dotnet build "Acme.BookStore.Report.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Acme.BookStore.Report.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acme.BookStore.Report.Blazor.dll"]
