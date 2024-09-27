# Coink Rest API

## Resumen

La Coink Rest API es una aplicación de interfaz de programación de aplicaciones (API) RESTful diseñada para facilitar el registro de usuarios y la consulta de información geográfica. Desarrollada utilizando tecnologías modernas, esta API proporciona una solución robusta y escalable para la gestión de datos de usuarios.

## Especificaciones Técnicas

- **Sistema Operativo:** Windows
- **Lenguaje de Backend:** C#
- **Framework:** ASP.NET 8.0.401
- **Tipo de Aplicación:** REST API
- **Sistema de Gestión de Base de Datos:** PostgreSQL 13.11
- **Arquitectura:** Diseño por capas

## Estructura del Proyecto

- **Solución C#:** CoinkRestAPI.sln
- **Proyecto C#:** CoinkRestAPI
- **Proyecto PostgreSQL:** postgres_db

## Funcionalidades Principales

1. **Registro de Usuarios:**
   La API permite el registro de usuarios con los siguientes campos:
   - `user_id`: Número de documento de identidad (identificador único)
   - `name`: Nombre del usuario
   - `phone`: Número telefónico
   - `country_id`: Identificador del país de residencia
   - `state_id`: Identificador del departamento o estado
   - `city_id`: Identificador de la ciudad

   Nota: Se garantiza un registro único por usuario basado en `user_id` y `country_id`.

2. **Consulta de Información Geográfica:**
   Proporciona endpoints para consultar los identificadores de países, departamentos/estados y ciudades/municipios, facilitando el proceso de registro. Se incluyen datos para Colombia y algunos de España con fines de prueba.

Para una documentación detallada de los endpoints y sus funcionalidades, por favor consulte la documentación Swagger disponible en la ruta `/swagger`.

## Instrucciones de Despliegue Local

### 1. Configuración de la Base de Datos

Ejecute el script `init_db.bat` ubicado en el directorio `postgresql_db`. Este script automatiza la configuración de la base de datos utilizando la CLI de PostgreSQL.

- Se le solicitará ingresar el usuario y contraseña para la autenticación.
- Opcionalmente, puede insertar datos de prueba correspondientes a la información geográfica de Colombia.

### 2. Configuración de Dependencias

En el directorio `/CoinkRestAPI`, ejecute el siguientes comando para restaurar las dependencias del proyecto:

````
dotnet restore
````

### 3. Configuración de Secrets

En el directorio `/CoinkRestAPI`, ejecute los siguientes comandos para configurar las variables de conexión a la base de datos:

````
dotnet user-secrets init
dotnet user-secrets set "HOST" "Su_host"
dotnet user-secrets set "USERNAME" "Su_username"
dotnet user-secrets set "PASSWORD" "Su_contraseña"
````


### 4. Compilación de la API

Posiciónese en el directorio `/CoinkRestAPI` y ejecute:

````
dotnet build
````
### 5. Ejecución de la API

Para iniciar la API, ejecute:

````
dotnet run
````

## Soporte y Contacto

Para consultas técnicas o soporte, mi correo de contacto es sgaravito@unal.edu.co. 