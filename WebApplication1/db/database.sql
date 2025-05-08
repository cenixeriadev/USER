-- Crear base de datos
CREATE DATABASE myroom;
GO

-- Usar base de datos
USE myroom;
GO

-- Tabla: Categorias
CREATE TABLE Categorias (
    categoria_id INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Tabla: Marcas
CREATE TABLE Marcas (
    marca_id INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Tabla: Clientes
CREATE TABLE Clientes (
    cliente_id INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    telefono NVARCHAR(15),
    direccion NVARCHAR(255),
    fecha_registro DATE DEFAULT GETDATE()
);

-- Tabla: Proveedores
CREATE TABLE Proveedores (
    proveedor_id INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    contacto NVARCHAR(100),
    telefono NVARCHAR(15),
    direccion NVARCHAR(255)
);

-- Tabla: Productos
CREATE TABLE Productos (
    producto_id INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    marca_id INT NOT NULL,
    categoria_id INT NOT NULL,
    descripcion NVARCHAR(MAX),
    precio DECIMAL(10, 2) NOT NULL,
    color NVARCHAR(50),
    talla NVARCHAR(10),
    genero NVARCHAR(20),
    fecha_creacion DATE DEFAULT GETDATE(),
    FOREIGN KEY (marca_id) REFERENCES Marcas(marca_id),
    FOREIGN KEY (categoria_id) REFERENCES Categorias(categoria_id)
);

-- Tabla: Inventario
CREATE TABLE Inventario (
    inventario_id INT IDENTITY PRIMARY KEY,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    ubicacion NVARCHAR(100),
    FOREIGN KEY (producto_id) REFERENCES Productos(producto_id)
);

-- Tabla: Ordenes
CREATE TABLE Ordenes (
    orden_id INT IDENTITY PRIMARY KEY,
    cliente_id INT NOT NULL,
    fecha_orden DATE DEFAULT GETDATE(),
    estado NVARCHAR(50),
    monto_total DECIMAL(10, 2) NOT NULL,
    metodo_pago NVARCHAR(50),
    FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id)
);

-- Tabla: Detalle de Orden
CREATE TABLE Detalle_Orden (
    detalle_id INT IDENTITY PRIMARY KEY,
    orden_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal AS (cantidad * precio_unitario) PERSISTED,
    FOREIGN KEY (orden_id) REFERENCES Ordenes(orden_id),
    FOREIGN KEY (producto_id) REFERENCES Productos(producto_id)
);

-- Tabla: Proveedor_Producto
CREATE TABLE Proveedor_Producto (
    proveedor_producto_id INT IDENTITY PRIMARY KEY,
    proveedor_id INT NOT NULL,
    producto_id INT NOT NULL,
    precio_compra DECIMAL(10, 2),
    fecha_ultima_compra DATE,
    FOREIGN KEY (proveedor_id) REFERENCES Proveedores(proveedor_id),
    FOREIGN KEY (producto_id) REFERENCES Productos(producto_id)
);
