create database cartshop; 

use cartshop;

create table Usuarios (
	id int identity,
	nombre varchar(max),
	email varchar(50),
	planId int,
	telefono varchar(max),
	clave varchar(max)
	primary key (email),
	foreign key (planId) references Planes(IdPlan)
)


create table Planes (
	IdPlan int primary key identity,
	nombre varchar(max),
	icono varchar(max),
	descripcion varchar(max),
	valor decimal,
	frecuencia varchar(max),
	codigo varchar(max),
)

create table Productos (
	id int primary key identity,
	descripcion varchar(max),
	precio decimal,
	estado bit,
	detalle varchar(max),
	imagen varchar(max)
)

create table PlanesProductos(
	idPlan int,
	idProducto int 
	Foreign Key(idPlan) references Planes(idPlan),
	Foreign Key(idProducto) references Productos(id),
)