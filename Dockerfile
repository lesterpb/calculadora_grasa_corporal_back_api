# Usa la imagen base de .NET Core 6
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia el archivo de proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos del proyecto
COPY . ./

# Compila el proyecto
RUN dotnet build -c Release --no-restore

# Publica el proyecto
RUN dotnet publish -c Release --no-restore -o out

# Configura la imagen de producción final
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto en el que la aplicación escucha
EXPOSE 80

# Ejecuta la aplicación
ENTRYPOINT ["dotnet", "calculadora_grasa_corporal_back_api.dll"]
