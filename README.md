# Prueba Tiendeo

### BBDD

[Scripts de Creación de Base de Datos](https://github.com/adri-dev/Tiendeo-WEB/blob/master/TiendeoDB/TiendeoWebDBCreationsScript.sql)

[Querys](https://github.com/adri-dev/Tiendeo-WEB/blob/master/TiendeoDB/TiendeoWebDBQuerys.sql)

En la parte de Base de Datos:
1. Los scripts de creación de datos son para SQLServer
2. Me he basado en la definición del PDF y los Json que este contenía.

### [API](https://github.com/adri-dev/Tiendeo-WEB/tree/master/TiendeoApi)
He creado dos proyectos para esta prueba:
1. [Proyecto de API](https://github.com/adri-dev/Tiendeo-WEB/tree/master/TiendeoApi/TiendeoApi)
2. [Proyecto de Test](https://github.com/adri-dev/Tiendeo-WEB/tree/master/TiendeoApi/TiendeoApiTest)

Para la creación de la API:
1. Esta creada con Net Core 2.2.
2. La parte de acceso a datos está implementada con Entity Framework Core.
3. Se utiliza AutoMapper y Dependency Injection.
4. Para el proyecto de Test se usa un Proyecto NUnit y para el Mocking el Framework Moq.

### [Web](https://github.com/adri-dev/Tiendeo-WEB/tree/master/TiendeoWEB)
Para la creación de la Web:
1. Esta creada con Net Core MVC 2.2.
2. La parte de acceso a datos está implementada con Entity Framework Core.
3. Se utiliza AutoMapper y Dependency Injection.
