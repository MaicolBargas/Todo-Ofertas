create database TodoOfertas;
use TodoOfertas;

create table Usuario(
Ci int primary key,
Nombre varchar(25) not null,
Mail varchar(35) unique not null ,
Password varchar(80) unique not null
);

create table Admin(
Ci int primary key,
Nombre varchar(25) not null,
Mail varchar(35) unique not null ,
Password varchar(80) unique not null,
Code int unique not null,
);

create table Oferta(
Id int identity(1500, 1) primary key,
Titulo varchar(20) not null,
Descripcion varchar(60) not null,
Precio int not null,
Descuento int not null,
PrecioFinal as Precio-(Precio*Descuento/100)
);

create table Venta(
Id int identity(1,1) primary key,
CiComprador int references Usuario(Ci),
IdOferta int references Oferta(Id)
);


CREATE Or alter PROCEDURE ListarOferta
AS
BEGIN
	SELECT * FROM Oferta
END
------------
CREATE Or alter PROCEDURE ListarAdmin
AS
BEGIN
	SELECT * FROM Admin
END
------------
CREATE Or alter PROCEDURE ListarUsuario
AS
BEGIN
	SELECT * FROM Usuario
END
------------
Create or alter procedure AltaUsuario
	@Ci int,
	@Nombre varchar(25),
	@Mail varchar(25),
	@Password varchar(80)
AS
BEGIN
		Insert into Usuario VALUES (@Ci,@Nombre,@Mail,@Password)
END
------------
CREATE or alter PROCEDURE AltaOferta
	@Titulo varchar(20),
	@Descripcion varchar(60),
	@Precio int,
	@Descuento int
AS
BEGIN
    INSERT INTO Oferta(Titulo,Descripcion,Precio,Descuento) VALUES (@Titulo,@Descripcion,@Precio,@Descuento)
END
------------
CREATE or ALTER PROCEDURE BajaOferta
	@Id int
AS
BEGIN
		DELETE FROM Oferta WHERE Id = @Id;
END
------------
CREATE or alter PROCEDURE AltaVenta
	@CiComprador int,
	@IdOferta int
AS
BEGIN
    INSERT INTO Venta VALUES (@CiComprador,@IdOferta)
END
------------

------------

------------
																
insert into Admin values(55555555, 'admin', 'admin@gmail.com', 'b20b0f63ce2ed361e8845d6bf2e59811aaa06ec96bcdb92f9bc0c5a25e83c9a6', 100);
