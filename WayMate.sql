-- CREATE DATABASE WayMate;
GO
-- Switching to the WayMate database
USE WayMate;
GO

drop table dbo.admin
go

drop table dbo.booking
go

drop table dbo.trip
go

drop table dbo.driver
go

drop table dbo.car
go

drop table dbo.passenger
go

drop table dbo.address
go

drop table dbo.users
go

-- Creating the 'users' table
CREATE TABLE users (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    username VARCHAR(20) NOT NULL,
    password VARCHAR(200) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    birthDate DATE NOT NULL
);

-- Creating the 'address' table
CREATE TABLE address (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    street VARCHAR(50) NOT NULL,
    postalCode VARCHAR(6) NOT NULL,
    city VARCHAR(50) NOT NULL,
    number VARCHAR(6) NOT NULL
);

-- Creating the 'passenger' table
CREATE TABLE passenger (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    userId INT NOT NULL REFERENCES users(id),
    lastName VARCHAR(50) NOT NULL,
    firstName VARCHAR(50) NOT NULL,
    gender VARCHAR(20) NOT NULL,
    addressId INT NOT NULL REFERENCES address(id)
);

-- Creating the 'car' table
CREATE TABLE car (
    plateNumber VARCHAR(50) PRIMARY KEY NOT NULL,
    model VARCHAR(50) NOT NULL,
    nbSeats INT NOT NULL,
    brand VARCHAR(50) NOT NULL
);

-- Creating the 'driver' table
CREATE TABLE driver (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    passengerId INT NOT NULL REFERENCES passenger(id),
    carPlate VARCHAR(50) NOT NULL REFERENCES car(plateNumber)
);

-- Creating the 'admin' table
CREATE TABLE admin (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    idUser INT NOT NULL REFERENCES users(id)
);

-- Creating the 'trip' table
CREATE TABLE trip (
    id INT IDENTITY PRIMARY KEY NOT NULL,
    idDriver INT NOT NULL REFERENCES driver(id),
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
    idPassenger INT NOT NULL REFERENCES passenger(id),
    idEntryPoint INT NOT NULL REFERENCES address(id),
    idTrip INT NOT NULL REFERENCES trip(id)
);

Go

-- Adding the 'carType' column to the 'car' table
ALTER TABLE car ADD carType INT NOT NULL DEFAULT 0;
-- ALTER TABLE car ADD carType VARCHAR(15) NOT NULL DEFAULT 'Universal';
ALTER TABLE car ADD fuelType INT NOT NULL DEFAULT 0;
-- ALTER TABLE car ADD carType VARCHAR(15) NOT NULL DEFAULT 'Universal';

-- Adding the 'isBanned' column to the 'users' table
ALTER TABLE users ADD isBanned BIT NOT NULL DEFAULT 0;

-- Checking the existence of the 'birtDate' column before renaming
IF COL_LENGTH('users', 'birtDate') IS NOT NULL
BEGIN
    -- Renaming the column
    EXEC sp_rename 'users.birtDate', 'birthDate', 'COLUMN';
END
