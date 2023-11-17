-- Insertion d'utilisateurs
INSERT INTO users (username, password, birthDate) VALUES
    ('luke_skywalker', 'password123', '1980-05-25'),
    ('leia_organa', 'pass456', '1983-09-19'),
    ('han_solo', 'soloPass', '1977-04-29');

-- Insertion d'adresses
INSERT INTO address (street, postalCode, city, number) VALUES
    ('Tatooine Street', '12345', 'Mos Eisley', '1'),
    ('Alderaan Avenue', '67890', 'Aldera', '5'),
    ('Corellia Road', '54321', 'Corellia', '9');

-- Insertion de passagers
INSERT INTO passenger (userId, lastName, firstName, gender, addressId) VALUES
    (1, 'Skywalker', 'Luke', 'Male', 1),
    (2, 'Organa', 'Leia', 'Female', 2),
    (3, 'Solo', 'Han', 'Male', 3);

-- Insertion de voitures
INSERT INTO car (plateNumber, model, nbSeats, fuelType, brand, carType) VALUES
    ('ABC123', 'Millennium Falcon', 5, 'Hyperfuel', 'Corellian Engineering Corporation', 'Spaceship'),
    ('DEF456', 'X-34 Landspeeder', 2, 'Electric', 'SoroSuub Corporation', 'Landspeeder'),
    ('GHI789', 'Slave I', 3, 'Jet fuel', 'Kuat Systems Engineering', 'Spaceship');

-- Insertion de conducteurs
INSERT INTO driver (passengerId, carPlate) VALUES
    (1, 'ABC123'),
    (3, 'DEF456'),
    (2, 'GHI789');

-- Insertion d'administrateurs
INSERT INTO admin (idUser) VALUES
    (1),
    (2);

-- Insertion de trajets
INSERT INTO trip (idDriver, smoke, priceKm, luggage, petFriendly, date, occupiedSeats, idStartingPoint, idDestination) VALUES
    (1, 0, 0.5, 1, 1, '2023-11-01 08:00:00', 3, 1, 2),
    (2, 1, 0.3, 1, 0, '2023-11-02 12:30:00', 2, 2, 3),
    (3, 0, 0.8, 0, 1, '2023-11-03 15:45:00', 1, 3, 1);

-- Insertion de réservations
INSERT INTO booking (date, reservedSeats, idPassenger, idEntryPoint, idTrip) VALUES
    ('2023-10-30 10:00:00', 2, 2, 2, 1),
    ('2023-10-31 14:15:00', 1, 1, 1, 2),
    ('2023-11-01 20:30:00', 3, 3, 3, 3);
