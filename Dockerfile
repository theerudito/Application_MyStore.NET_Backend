# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar los archivos de la solución y restaurar las dependencias
COPY ./*.sln ./
COPY ./Store.Backend/*.csproj ./Store.Backend/
COPY ./Store.Database/*.csproj ./Store.Database/
COPY ./Store.DTO/*.csproj ./Store.DTO/
COPY ./Store.Models/*.csproj ./Store.Models/
COPY ./Store.Repository/*.csproj ./Store.Repository/
COPY ./Store.Service/*.csproj ./Store.Service/
COPY ./Store.Utils/*.csproj ./Store.Utils/

# Restaurar las dependencias
RUN dotnet restore

# Copiar todo el código fuente y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .


# Define el comando de inicio para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Store.Backend.dll"] 