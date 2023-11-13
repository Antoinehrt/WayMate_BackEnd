CREATE DATABASE waymate;

USE waymate;

create table users(
    id int identity primary key not null,
    username varchar(20) not null,
    password varchar(200) not null,
    birtDate date not null
);

create table address(
    id int identity primary key not null,
    street varchar(50) not null,
    postalCode varchar(6) not null,
    city varchar(50) not null,
    number varchar(6) not null
);

create table passenger(
    id int identity primary key not null,
    userId int not null references users(id),
    lastName varchar(50) not null,
    firstName varchar(50) not null,
    gender varchar(20) not null,
    addressId int not null references address(id)
);

create table car(
    plateNumber varchar(50) primary key not null,
    model varchar(50) not null,
    nbSeats int not null,
    fuelType varchar(20) not null,
    brand varchar(50) not null
);

create table driver(
    id int identity primary key not null,
    passengerId int not null references passenger(id),
    carPlate varchar(50) not null references car(plateNumber)

);

create table admin(
    id int identity primary key not null,
    idUser int not null references users(id)
);

create table trip(
    id int identity primary key not null,
    idDriver int not null references driver(id),
    smoke bit not null,
    priceKm float not null,
    luggage bit not null,
    petFriendly bit not null,
    date Datetime not null,
    occupiedSeats int not null,
    idStartingPoint int not null references address(id),
    idDestination int not null references address(id)
);

create table booking(
    id int identity primary key not null,
    date datetime not null,
    reservedSeats int not null,
    idPassenger int not null references passenger(id),
    idEntryPoint int not null references address(id),
    idTrip int not null references trip(id)
);