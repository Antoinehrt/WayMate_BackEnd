CREATE DATABASE waymate;

USE waymate;

CREATE TABLE users(
    id INT IDENTITY PRIMARY KEY NOT NULL,
    username VARCHAR(20) NOT NULL ,
    password VARCHAR(200) NOT NULL ,
    birtDate DATE NOT NULL
);

CREATE TABLE address(
    id INT IDENTITY PRIMARY KEY NOT NULL,
    street VARCHAR(50) NOT NULL,
    postalCode VARCHAR(6) NOT NULL,
    city VARCHAR(50) NOT NULL,
    number VARCHAR(6) NOT NULL
);

CREATE TABLE passenger(
    id INT IDENTITY PRIMARY KEY NOT NULL,
    userId INT NOT NULL REFERENCES users(id),
    lastName VARCHAR(50) NOT NULL,
    firstName VARCHAR(50) NOT NULL,
    gender VARCHAR(20) not null,
    addressId INT NOT NULL REFERENCES address(id)
);

CREATE TABLE car(
    plateNumber VARCHAR(50) PRIMARY KEY NOT NULL,
    model VARCHAR(50) NOT NULL,
    nbSeats INT NOT NULL,
    fuelType VARCHAR(20) NOT NULL ,
    brand VARCHAR(50) NOT NULL
);

CREATE TABLE driver(
    id INT IDENTITY  PRIMARY KEY NOT NULL,
    passengerId INT NOT NULL REFERENCES passenger(id),
    carPlate VARCHAR(50) NOT NULL REFERENCES car(plateNumber)

);

CREATE TABLE admin(
    id INT IDENTITY PRIMARY KEY NOT NULL,
    idUser INT NOT NULL REFERENCES users(id)
);

CREATE TABLE trip(
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

CREATE TABLE booking(
    id INT IDENTITY PRIMARY KEY NOT NULL,
    date DATETIME NOT NULL,
    reservedSeats INT NOT NULL,
    idPassenger INT NOT NULL REFERENCES passenger(id),
    idEntryPoint INT NOT NULL REFERENCES address(id),
    idTrip INT NOT NULL REFERENCES trip(id)
);

ALTER TABLE car ADD carType VARCHAR(15) NOT NULL default 'Universal';