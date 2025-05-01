create database BibliotecaPrivada
go
use BibliotecaPrivada
go
create table Libro(
ID int primary key identity(1,1),
Titulo nvarchar(64),
Precio decimal(10,2),
Stock int
)
go
create table Cliente(
ID int primary key identity(1,1),
Nombre nvarchar(64),
Email nvarchar(64),
Clave nvarchar(32),
Saldo decimal(10,2)
)
go
create table Pedido(
ID int primary key identity(1,1),
IDCliente int,
Libros nvarchar(128),
Total decimal(10,2),
Fecha datetime
foreign key(IDCliente) references Cliente(ID)
)
go
create table Pago(
ID int primary key identity(1,1),
IDPedido int,
Monto decimal(10,2),
MetodoPago nvarchar(20),
Fecha datetime,
NumeroTarjeta nvarchar(32)
)
go
