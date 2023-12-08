-- CREATE DATABASE WayMate;
GO

USE WayMate;
GO

drop table dbo.booking;
go

drop table dbo.trip;
go

drop table dbo.car;
go

drop table dbo.address;
go

drop table dbo.users;
go

-- Creating the 'address' table
CREATE TABLE address (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    street VARCHAR(50) NOT NULL,
    postalCode VARCHAR(6) NOT NULL,
    city VARCHAR(50) NOT NULL,
    number VARCHAR(6) NOT NULL
);

-- Creating the 'car' table
CREATE TABLE car (
    plateNumber VARCHAR(50) PRIMARY KEY NOT NULL,
    model VARCHAR(50) NOT NULL,
    nbSeats INT NOT NULL,
    brand VARCHAR(50) NOT NULL,
    carType INT NOT NULL DEFAULT 0,
    fuelType INT NOT NULL DEFAULT 0
);

-- Creating the 'users' table
CREATE TABLE users (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    userType VARCHAR(10) NOT NULL,
    username VARCHAR(20) NOT NULL,
    password VARCHAR(200) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    birthDate DATE NOT NULL,
    isBanned BIT NOT NULL DEFAULT 0,
    phoneNumber VARCHAR(16) NOT NULL,
    lastName VARCHAR(50),
    firstName VARCHAR(50),
    gender VARCHAR(20),
    addressId INT REFERENCES address(id),
    carPlate VARCHAR(50) REFERENCES car(plateNumber)
);

-- Creating the 'trip' table
CREATE TABLE trip (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    idDriver INT NOT NULL REFERENCES users(id),
    smoke BIT NOT NULL,
    priceKm FLOAT NOT NULL,
    luggage BIT NOT NULL,
    petFriendly BIT NOT NULL,
    date DATETIME NOT NULL,
    occupiedSeats INT NOT NULL,
    idStartingPoint INT NOT NULL REFERENCES address(id),
    idDestination INT NOT NULL REFERENCES address(id)
);

-- Creating the 'booking' table
CREATE TABLE booking (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    date DATETIME NOT NULL,
    reservedSeats INT NOT NULL,
    idPassenger INT NOT NULL REFERENCES users(id),
    idEntryPoint INT NOT NULL REFERENCES address(id),
    idTrip INT NOT NULL REFERENCES trip(id)
);