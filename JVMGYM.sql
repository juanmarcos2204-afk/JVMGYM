USE JVMGYM
GO

CREATE TABLE Clientes(
IdCliente INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
DNI VARCHAR(10),
Telefono VARCHAR(30), 
Domicilio VARCHAR(30),
FechaAlta DATETIME 
);
Go
CREATE TABLE DuracionesMembresias(
IdDuracionMembresia INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(30)
);
GO

CREATE TABLE Membresias(
IdMembresia INT PRIMARY KEY IDENTITY(1,1),
Tipo VARCHAR(30),
Precio DECIMAL(12,2),
IdDuracionMembresia INT NOT NULL,

FOREIGN KEY (IdDuracionMembresia) REFERENCES
DuracionesMembresias (IdDuracionMembresia) 
);
GO

CREATE TABLE ClientesMembresias(
IdClienteMembresia INT PRIMARY KEY IDENTITY(1,1),
IdCliente INT NOT NULL,
IdMembresia INT NOT NULL,
Inicio DATE,
Fin DATE,
Activo BIT,

FOREIGN KEY (IdCliente)
REFERENCES Clientes (IdCliente),
FOREIGN KEY (IdMembresia) 
REFERENCES Membresias (IdMembresia)
);
GO

CREATE TABLE MetodosDePago(
IdMetodoPago INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(30)
);
GO

CREATE TABLE Pagos(
IdPago INT PRIMARY KEY IDENTITY(1,1),
IdCliente INT, 
IdMetodoPago INT,
Fecha DATE,

FOREIGN KEY (IdCliente)
REFERENCES Clientes (IdCliente),
FOREIGN KEY (IdMetodoPago)
REFERENCES MetodosDePago (IdMetodoPago)
);
GO

