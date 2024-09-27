#!/bin/bash

# Solicitar el nombre de usuario
echo "Ingrese su username:"
read user

echo "Configuración de la base de datos ..."
echo "Database ..."
echo "Tables ..."
echo "Stored Procedures ..."
psql -U "$user" -f setup_db.sql -f setup_tables.sql -f setup_sp.sql 

# Preguntar si se desean cargar datos de prueba
echo "¿Desea cargar datos de prueba a las tablas? (Y/N):"
read dummie

if [ "${dummie,,}" = "y" ]; then
    echo "Cargando datos de prueba..."
    psql -U "$user" -f insert_countries.sql -f insert_states.sql -f insert_cities.sql
fi

echo "Base de datos creada con éxito."