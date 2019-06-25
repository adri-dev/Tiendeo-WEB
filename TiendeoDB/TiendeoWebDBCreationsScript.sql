CREATE TABLE 
master.dbo.Ciudad
(
	IdCiudad INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(30) NOT NULL,
	Provincia VARCHAR(30) NOT NULL,
	Latitud DECIMAL(9,6) NOT NULL,
	Longitud DECIMAL(9,6) NOT NULL,
	Rate INT NOT NULL
)


CREATE TABLE 
master.dbo.Negocio
(
	IdNegocio INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)  NOT NULL,
	Marker VARCHAR(100)  NOT NULL,
	Rate INT  NOT NULL
)

CREATE TABLE
master.dbo.Local
(
	IdLocal INT IDENTITY(1,1) PRIMARY KEY,
	IdCiudad INT  NOT NULL,
	IdNegocio INT  NOT NULL,
	Latitud DECIMAL(9,6)  NOT NULL,
	Longitud DECIMAL(9,6)  NOT NULL,
	Direccion VARCHAR(200),
	FOREIGN KEY (idCiudad) REFERENCES master.dbo.Ciudad (IdCiudad),
	FOREIGN KEY (idNegocio) REFERENCES master.dbo.Negocio (IdNegocio) 
)

CREATE TABLE
master.dbo.TipoServicio
(
	IdTipoServicio INT IDENTITY(1,1)  PRIMARY KEY,
	nombre VARCHAR(200) NOT NULL
)

CREATE TABLE
master.dbo.Servicio
(
	IdServicio INT IDENTITY(1,1) PRIMARY KEY,
	IdLocal INT NOT NULL,
	IdTipoServicio INT NOT NULL,
	nombre INT NOT NULL,
	Rate INT NOT NULL,
	FOREIGN KEY (IdLocal) REFERENCES master.dbo.Local (idLocal),
	FOREIGN KEY (IdTipoServicio) REFERENCES master.dbo.TipoServicio (idTipoServicio) 
)

CREATE TABLE
master.dbo.Tienda
(
	IdTienda INT IDENTITY(1,1) PRIMARY KEY,
	IdLocal INT NOT NULL,
	nombre VARCHAR(200) NOT NULL,
	Rate INT NOT NULL,
	FOREIGN KEY (IdLocal) REFERENCES master.dbo.Local (idLocal)
)