create database BibliotecaPrivada;
use BibliotecaPrivada;
CREATE TABLE IF NOT EXISTS Libros (
    ID INT PRIMARY KEY,
    Titulo VARCHAR(255) NOT NULL,
    Autor VARCHAR(255) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);
DROP TABLE IF EXISTS Cliente;
CREATE TABLE Cliente (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Clave VARCHAR(255) NOT NULL,
    Saldo decimal(10,2)
);

CREATE TABLE IF NOT EXISTS Pedido(
ID INT PRIMARY KEY,
IDCliente int,
Libros varchar(100),
Total decimal(10,2),
Fecha datetime,
foreign key(IDCliente) references Cliente(ID)
);

CREATE TABLE IF NOT EXISTS Pago(
ID INT PRIMARY KEY,
IDPedido int,
Monto decimal(10,2),
MetodoPago varchar(20),
Fecha Datetime,
NumeroTarjeta varchar(30)
);

INSERT INTO Cliente (Nombre, Email, Clave, Saldo) VALUES
('Laura Gómez', 'laura@example.com', 'clave123', 120.50),
('Carlos Méndez', 'carlos@example.com', 'clave456', 75.25),
('Sofía Ruiz', 'sofia@example.com', 'clave789', 200.00);

INSERT INTO Pedido (ID, IDCliente, Libros, Total, Fecha) VALUES
(1, 1, '1,2', 35.49, NOW()),
(2, 2, '3', 15.50, NOW()),
(3, 3, '2,3', 28.25, NOW());

INSERT INTO Pago (IDPedido, Monto, MetodoPago, Fecha, NumeroTarjeta) VALUES
(1,1, 35.49, 'Tarjeta', NOW(), '1234-5678-9012-3456'),
(2,2, 15.50, 'Efectivo', NOW(), NULL),
(3,3, 28.25, 'Tarjeta', NOW(), '9876-5432-1098-7654');

INSERT INTO Libros (Titulo, Autor, Precio, Stock) VALUES 
(1,'El Principito', 'Antoine de Saint-Exupéry', 10.99, 15),
(2,'1984', 'George Orwell', 12.50, 20),
(3,'Rayuela', 'Julio Cortázar', 13.75, 8);
