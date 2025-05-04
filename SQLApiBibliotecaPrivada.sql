
-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS BibliotecaPrivada;
USE BibliotecaPrivada;

-- Tabla Usuarios
CREATE TABLE IF NOT EXISTS Usuarios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL
);

-- Tabla Libros
CREATE TABLE IF NOT EXISTS Libros (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Titulo VARCHAR(255) NOT NULL,
    Autor VARCHAR(255) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);

-- Tabla Prestamos
CREATE TABLE IF NOT EXISTS Prestamos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    UsuarioID INT NOT NULL,
    LibroID INT NOT NULL,
    FechaPrestamo DATETIME DEFAULT NOW(),
    FechaDevolucion DATETIME,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID),
    FOREIGN KEY (LibroID) REFERENCES Libros(ID)
);

-- Datos de ejemplo para Usuarios
INSERT INTO Usuarios (Nombre, Correo, Contrasena)
VALUES 
('Juan Pérez', 'juan@example.com', '1234'),
('Ana Torres', 'ana@example.com', 'abcd');

-- Datos de ejemplo para Libros
INSERT INTO Libros (Titulo, Autor, Precio, Stock)
VALUES 
('Cien Años de Soledad', 'Gabriel García Márquez', 19.99, 10),
('Don Quijote de la Mancha', 'Miguel de Cervantes', 15.50, 7),
('La Sombra del Viento', 'Carlos Ruiz Zafón', 12.75, 5);

-- Datos de ejemplo para Prestamos
INSERT INTO Prestamos (UsuarioID, LibroID, FechaPrestamo)
VALUES 
(1, 1, NOW()),
(2, 2, NOW());
