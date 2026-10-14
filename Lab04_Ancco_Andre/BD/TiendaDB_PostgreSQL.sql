-- Crear la base de datos
CREATE DATABASE TiendaDB;

-- Conectar a la base de datos
\c TiendaDB;

-- Crear tabla de Clientes
CREATE TABLE Clientes (
    ClienteID SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Crear tabla de Productos
CREATE TABLE Productos (
    ProductoID SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255),
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL
);

-- Crear tabla de Categorías
CREATE TABLE Categorias (
    CategoriaID SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

-- Relacionar Productos con Categorías (Foreign Key)
ALTER TABLE Productos
ADD COLUMN CategoriaID INT;

ALTER TABLE Productos
ADD CONSTRAINT FK_Productos_Categorias FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID);

-- Crear tabla de Ordenes
CREATE TABLE Ordenes (
    OrdenID SERIAL PRIMARY KEY,
    ClienteID INT,
    FechaOrden TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Total DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Ordenes_Clientes FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

-- Crear tabla de Detalles de la Orden
CREATE TABLE DetallesOrden (
    DetalleID SERIAL PRIMARY KEY,
    OrdenID INT,
    ProductoID INT,
    Cantidad INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_DetallesOrden_Ordenes FOREIGN KEY (OrdenID) REFERENCES Ordenes(OrdenID),
    CONSTRAINT FK_DetallesOrden_Productos FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Crear tabla de Pagos
CREATE TABLE Pagos (
    PagoID SERIAL PRIMARY KEY,
    OrdenID INT,
    Monto DECIMAL(10, 2) NOT NULL,
    FechaPago TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    MetodoPago VARCHAR(50),
    CONSTRAINT FK_Pagos_Ordenes FOREIGN KEY (OrdenID) REFERENCES Ordenes(OrdenID)
);

-- Insertar datos de prueba

-- Insertar algunos Clientes
INSERT INTO Clientes (Nombre, Correo) VALUES ('Juan Perez', 'juan.perez@email.com');
INSERT INTO Clientes (Nombre, Correo) VALUES ('Maria Lopez', 'maria.lopez@email.com');
INSERT INTO Clientes (Nombre, Correo) VALUES ('Carlos Garcia', 'carlos.garcia@email.com');

-- Insertar algunas Categorías
INSERT INTO Categorias (Nombre) VALUES ('Electrónica');
INSERT INTO Categorias (Nombre) VALUES ('Ropa');
INSERT INTO Categorias (Nombre) VALUES ('Alimentos');

-- Insertar algunos Productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaID) VALUES ('Laptop', 'Laptop con 8GB de RAM', 750.00, 10, 1);
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaID) VALUES ('Camisa', 'Camisa de algodón', 25.00, 50, 2);
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaID) VALUES ('Cereal', 'Cereal de avena', 5.00, 100, 3);

-- Insertar algunas Ordenes
INSERT INTO Ordenes (ClienteID, Total) VALUES (1, 775.00);
INSERT INTO Ordenes (ClienteID, Total) VALUES (2, 30.00);

-- Insertar algunos Detalles de Orden
INSERT INTO DetallesOrden (OrdenID, ProductoID, Cantidad, Precio) VALUES (1, 1, 1, 750.00);
INSERT INTO DetallesOrden (OrdenID, ProductoID, Cantidad, Precio) VALUES (1, 2, 1, 25.00);
INSERT INTO DetallesOrden (OrdenID, ProductoID, Cantidad, Precio) VALUES (2, 2, 1, 25.00);

-- Insertar algunos Pagos
INSERT INTO Pagos (OrdenID, Monto, MetodoPago) VALUES (1, 775.00, 'Tarjeta de Crédito');
INSERT INTO Pagos (OrdenID, Monto, MetodoPago) VALUES (2, 30.00, 'Efectivo');