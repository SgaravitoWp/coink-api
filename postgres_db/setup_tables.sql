\c userregistration;

-- Eliminación de tablas existentes si existen
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS cities;
DROP TABLE IF EXISTS states;
DROP TABLE IF EXISTS countries;

CREATE EXTENSION pgcrypto;

-- Creación de la tabla de países
CREATE TABLE countries (
    id VARCHAR(3) PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

-- Creación de la tabla de departamentos
CREATE TABLE states (
    id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    country_id VARCHAR(3) NOT NULL,
    FOREIGN KEY (country_id) REFERENCES countries(id)
);

-- Creación de la tabla de municipios
CREATE TABLE cities (
    id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    state_id INT NOT NULL,
    FOREIGN KEY (state_id) REFERENCES states(id)
);

-- Creación de la tabla de usuarios
CREATE TABLE users (
    id VARCHAR(36) PRIMARY KEY DEFAULT gen_random_uuid(),
    user_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    address VARCHAR(255) NOT NULL,
    country_id VARCHAR(3) NOT NULL,
    state_id INT NOT NULL,
    city_id INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES countries(id),
    FOREIGN KEY (state_id) REFERENCES states(id),
    FOREIGN KEY (city_id) REFERENCES cities(id),
    CONSTRAINT unique_user UNIQUE (user_id, country_id)
);