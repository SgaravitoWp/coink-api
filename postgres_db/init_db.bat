@echo off

rem Ingrese su usuario root. 
SET /P user=Ingrese su username:

echo Configuracion de la base de datos ...
echo Database ...
echo Tables ...
echo Stored Procedures ...
psql -U %user%  -f setup_db.sql -f setup_tables.sql -f setup_sp.sql 

SET /P dummie=Desea cargar datos de prueba a las tablas ? (Y\N): 

IF "%dummie%"=="Y" (
    echo Cargando datos de prueba...
    psql -U %user% -f insert_countries.sql -f insert_states.sql -f insert_cities.sql
)
echo Base de datos creada con exito. 
