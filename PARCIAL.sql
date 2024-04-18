CREATE or replace TABLE Factura (
    Id INT PRIMARY KEY, 
    Id_cliente INT NOT NULL, 
    Nro_Factura VARCHAR(100) NOT NULL,
    Fecha_Hora VARCHAR(100) NOT NULL,
    Total INT NOT NULL,
    Total_iva5 INT NOT NULL,
    Total_iva10 INT NOT NULL,
    Total_iva INT NOT NULL,
    Total_letras VARCHAR(255) NOT NULL,
    Sucursal VARCHAR(100) NOT NULL,
    FOREIGN KEY (Id_cliente) REFERENCES Cliente(Id) 
);

CREATE or replace TABLE Cliente (
    Id INT PRIMARY KEY, 
    Id_banco INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Documento VARCHAR(20) NOT NULL,
    Direccion VARCHAR(255) NOT NULL,
    Mail VARCHAR(100) NOT NULL,
    Celular INT NOT NULL,
    Estado VARCHAR(50) NOT NULL
);


