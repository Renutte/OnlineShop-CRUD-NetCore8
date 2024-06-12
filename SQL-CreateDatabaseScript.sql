-- Seleccionar la base de datos TiendaOnline
USE OnlineShop;
GO

-- Consultar la versión de SQL Server
-- SELECT @@VERSION;

-- Eliminar la tabla de relación StoreProducts si existe
DROP TABLE IF EXISTS StoreProducts;

-- Eliminar la tabla Products si existe
DROP TABLE IF EXISTS Products;

-- Eliminar la tabla Stores si existe
DROP TABLE IF EXISTS Stores;

-- Crear la tabla Stores
CREATE TABLE Stores (
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    location VARCHAR(100) NOT NULL
);

-- Crear la tabla Products
CREATE TABLE Products (
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    size VARCHAR(50) NOT NULL,
    color VARCHAR(50) NOT NULL,
    price VARCHAR(50) NOT NULL,
    description VARCHAR(50)
);

-- Crear la tabla de relación StoreProducts
CREATE TABLE StoreProducts (
    StoreId INT NOT NULL,
    ProductId INT NOT NULL,
    stock INT NOT NULL,
    CONSTRAINT FK_StoreProducts_Stores FOREIGN KEY (StoreId) REFERENCES Stores(id),
    CONSTRAINT FK_StoreProducts_Products FOREIGN KEY (ProductId) REFERENCES Products(id),
    PRIMARY KEY (StoreId, ProductId)
);

-- Insertar datos en la tabla Stores
INSERT INTO Stores (location, name) VALUES 
('Downtown', 'Downtown Store'),
('Uptown', 'Uptown Store');

-- Insertar datos en la tabla Products
INSERT INTO Products (name, size, color, price, description) VALUES 
('Producto1', 'M', 'Red', '19.99', 'Comfortable red t-shirt'),
('Producto2', 'L', 'Blue', '25.50', 'Blue jeans with a classic fit'),
('Producto3', 'S', 'Green', '15.75', 'Green summer dress'),
('Producto4', 'XL', 'Black', '30.00', 'Black hoodie with front pocket'),
('Producto5', 'M', 'White', '20.00', 'White cotton shirt');

-- Insertar datos en la tabla de relación StoreProducts
INSERT INTO StoreProducts (StoreId, ProductId, stock) VALUES
(1, 1, 10), -- Producto 1 en Tienda 1 con stock de 10
(1, 2, 5),  -- Producto 2 en Tienda 1 con stock de 5
(2, 3, 20), -- Producto 3 en Tienda 2 con stock de 20
(2, 4, 15), -- Producto 4 en Tienda 2 con stock de 15
(2, 5, 25), -- Producto 5 en Tienda 2 con stock de 25
(1, 3, 8);  -- Producto 3 también en Tienda 1 con stock de 8

-- Seleccionar todos los productos junto con la información de la tienda y el stock
SELECT s.id AS StoreId, s.location, s.name, p.id AS ProductId, p.name AS ProductName, p.size, p.color, p.price, p.description, sp.stock
FROM StoreProducts sp
JOIN Stores s ON sp.StoreId = s.id
JOIN Products p ON sp.ProductId = p.id;

SELECT * FROM StoreProducts;

SELECT * FROM Products;
