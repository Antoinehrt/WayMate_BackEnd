-- Inserting addresses
INSERT INTO address (street, postalCode, city, number) VALUES
    ('Main Street', '12345', 'Cityville', '1'),
    ('Star Avenue', '54321', 'Galaxy City', '42'),
    ('Millennium Square', '67890', 'Spaceport', '7');
GO
-- Inserting cars
INSERT INTO car (plateNumber, model, nbSeats, brand, carType, fuelType) VALUES
    ('ABC123', 'Millennium Falcon', 5, 'Corellian Engineering Corporation', 0, 0),
    ('DEF456', 'X-34 Landspeeder', 2, 'SoroSuub Corporation', 0, 0),
    ('GHI789', 'Slave I', 3, 'Kuat Systems Engineering', 0, 0);
GO
-- Inserting users
INSERT INTO users (userType, username, password, email, birthDate, isBanned, phoneNumber, lastName, firstName, gender, addressId, carPlate) VALUES
    ('Driver', 'luke_skywalker', 'password123', 'luke@example.com', '1980-05-25', 0, '1234567890', 'Skywalker', 'Luke', 'Male', 1, 'ABC123'),
    ('Passenger', 'leia_organa', 'pass456', 'leia@example.com', '1983-09-19', 0, '9876543210', 'Organa', 'Leia', 'Female', 2, 'DEF456'),
    ('Admin', 'han_solo', 'soloPass', 'han@example.com', '1977-04-29', 0, '6543210987', 'Solo', 'Han', 'Male', 3, 'GHI789');
GO
-- Inserting trips
INSERT INTO trip (idDriver, smoke, priceKm, luggage, petFriendly, date, occupiedSeats, idStartingPoint, idDestination) VALUES
    (1, 0, 0.5, 1, 1, '2023-11-01 08:00:00', 3, 1, 2),
    (2, 1, 0.3, 1, 0, '2023-11-02 12:30:00', 2, 2, 3),
    (3, 0, 0.8, 0, 1, '2023-11-03 15:45:00', 1, 3, 1);
GO
-- Inserting bookings
INSERT INTO booking (date, reservedSeats, idPassenger, idEntryPoint, idTrip) VALUES
    ('2023-10-30 10:00:00', 2, 2, 2, 1),
    ('2023-10-31 14:15:00', 1, 1, 1, 2),
    ('2023-11-01 20:30:00', 3, 3, 3, 3);
