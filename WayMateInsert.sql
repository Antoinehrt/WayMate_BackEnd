USE WayMate;

-- Inserting addresses
INSERT INTO address (street, postalCode, city, number) VALUES
    ('Tatooine Street', '12345', 'Mos Eisley', '1'),
    ('Alderaan Avenue', '67890', 'Aldera', '5'),
    ('Corellia Road', '54321', 'Corellia', '9');

-- Inserting cars
INSERT INTO car (plateNumber, model, nbSeats, brand, carType, fuelType) VALUES
    ('ABC123', 'Millennium Falcon', 5, 'Corellian Engineering Corporation', 0, 0);

-- Inserting users
INSERT INTO users (userType, username, password, email, birthDate, isBanned, lastName, firstName, gender, addressId, carPlate) VALUES
    ('PASSENGER', 'MastroDamo87', 'test', 'mastrodamo@test.be', '2003-09-08', 0, 'Renaut', N'Mickaël', 'Male', '1', null),
    ('DRIVER', 'NextAndCie', 'test', 'nextandcie@multi.dimension.be', '1987-11-13', 0, 'Dimen', 'Undernext', 'Male', 2, 'ABC123'),
    ('ADMIN', 'NextOS', 'admin', 'NextOS@dimension.net', '1990-01-01', 0, null, null, null, null, null);

-- Inserting trips
INSERT INTO trip (idDriver, smoke, priceKm, luggage, petFriendly, date, occupiedSeats, idStartingPoint, idDestination) VALUES
    (2, 0, 0.5, 1, 1, '2023-11-01 08:00:00', 1, 1, 2);

-- Inserting bookings
INSERT INTO booking (date, reservedSeats, idPassenger, idEntryPoint, idTrip) VALUES
    ('2023-10-30 10:00:00', 2, 1, 2, 1),
    ('2023-10-31 14:15:00', 1, 1, 1, 1),
    ('2023-11-01 20:30:00', 3, 1, 3, 1);
