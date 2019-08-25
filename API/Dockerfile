#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["API/Biblioteca.API.csproj", "API/"]
COPY ["Aplicacao/Biblioteca.Aplicacao.csproj", "Aplicacao/"]
COPY ["Dominio/Biblioteca.Dominio.csproj", "Dominio/"]
COPY ["Infra/Biblioteca.Infra.csproj", "Infra/"]
RUN dotnet restore "API/Biblioteca.API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "Biblioteca.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Biblioteca.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Biblioteca.API.dll"]