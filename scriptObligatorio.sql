create database clinica_ucu_salud;
use clinica_ucu_salud;

create table Logins(
   LogId int auto_increment,
   Password varchar(100) not null,
   primary key (LogId)
);

create table Funcionarios(
    CI int,
    Nombre varchar(60) not null,
    Apellido varchar(60) not null,
    Fch_Nacimiento date not null,
    Direccion varchar(200) not null,
    Telefono int not null,
    Email varchar(120) not null,
    LogId int not null,
    PRIMARY KEY (CI),
    FOREIGN KEY (LogId) references Logins(LogId)
);

create table Agenda(
    Nro int auto_increment,
    CI int not null,
    Fch_Agenda date not null,
    primary key (Nro),
    foreign key (CI) references Funcionarios(CI)
);

create table Carnet_Salud(
    CI int not null,
    Fch_Emision date not null,
    Fch_Vencimiento date not null,
    Comprobante varchar(500) not null,
    primary key (CI, Fch_Emision),
    FOREIGN KEY (CI) references Funcionarios(CI)
);

create table Periodos_Actualizacion(
    Año int not null,
    Semestre int not null,
    Fch_Inicio date not null,
    Fch_Fin date not null,
    primary key (Fch_Inicio, Fch_Fin)
);

INSERT INTO Logins values (1,123);