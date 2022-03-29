# Prueba BACK-END
Programacion Back-End C# Net Core 5 Entity Framework Core

# Implementacion y configuracion de Base
Se requiere Crear una base de datos en Sql server con el nombre: NTTData

El scrip del esquema es BaseDatos.sql

Se requiere configurar las propiedades de la aplicacion en la siguiente ruta:

Api/appsettings

"ConnectionStrings": {
    "DefaultConnection": "Server=<server></server>;Database=NTTData;Trusted_Connection=True;"
}

# Open Api Swagger
puerto configurado

- http://localhost:<port>/swagger/index.html